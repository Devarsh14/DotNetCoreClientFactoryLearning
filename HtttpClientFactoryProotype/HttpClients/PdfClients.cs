

using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HtttpClientFactoryProotype.Dto;

namespace HtttpClientFactoryProotype.HttpClients
{
    public class PdfClient
    {
        private readonly HttpClient httpClient;
        private readonly HttpContext httpContext;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly ILogger logger;
        private readonly IConfiguration configuration;

        public PdfClient(HttpClient httpClient, IHttpContextAccessor httpContextAccessor, IHostingEnvironment hostingEnvironment, ILogger<PdfClient> logger, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            this.httpContext = httpContextAccessor.HttpContext;
            this.hostingEnvironment = hostingEnvironment;
            this.logger = logger;
            this.configuration = configuration;
        }

        /// <summary>
        /// HTTP Client to get a byte[] PDF based on a Pdf model.
        /// </summary>
        /// <returns>File bytes or null if an error occurs.</returns>
        public async Task<byte[]> GetPdfFromHtml(PdfDto pdfDto)
        {
            // Get user access token to the PDF api
            try
            {
                var disco = await DiscoveryClient.GetAsync(this.configuration.GetSection("IdentityConfiguration")["OversiIdentityServerHost"].ToString());
                var tokenClient = new TokenClient(disco.TokenEndpoint, this.configuration.GetSection("IdentityConfiguration")["ClientId"].ToString(), this.configuration.GetSection("IdentityConfiguration")["ClientSecret"].ToString());
                var tokenResponse = await tokenClient.RequestClientCredentialsAsync("pdfapi");

                this.httpClient.SetBearerToken(tokenResponse.AccessToken);
                var response = await this.httpClient.PostAsJsonAsync<PdfDto>("api/PdfCreator/PostPdfBytes", pdfDto).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                // Parse the response (true or false)
                string data = await response.Content.ReadAsStringAsync();

                // Convert the string to bytes
                byte[] pdfBytes = Convert.FromBase64String(data);

                // Return the bytes
                return pdfBytes;
            }
            catch (HttpRequestException ex)
            {
                string errorMessage = "An error occurred genarating the PDF";

                if (ex.InnerException != null)
                {
                    errorMessage += this.hostingEnvironment.IsDevelopment() == true ? ". Error status: " + ex.InnerException.Message.ToString() : string.Empty;
                }
                else
                {
                    errorMessage += this.hostingEnvironment.IsDevelopment() == true ? ". Error status: " + ex.Message.ToString() : string.Empty;
                }

                this.logger.LogError(errorMessage);

                return null;
            }
            catch (Exception ex)
            {
                string errorMessage = "An error occurred genarating the PDF";

                if (ex.InnerException != null)
                {
                    errorMessage += this.hostingEnvironment.IsDevelopment() == true ? ". Error status: " + ex.InnerException.Message.ToString() : string.Empty;
                }
                else
                {
                    errorMessage += this.hostingEnvironment.IsDevelopment() == true ? ". Error status: " + ex.Message.ToString() : string.Empty;
                }

                this.logger.LogError(errorMessage);

                return null;
            }
        }
    }
}
