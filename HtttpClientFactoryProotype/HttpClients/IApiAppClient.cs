using System;

using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
    using System.Net.Http.Headers;


namespace HtttpClientFactoryProotype.HttpClients
{

    /// <summary>
    /// Define interface to do multiple activites for the httpclient
    /// 
    /// </summary>
    public interface IApiAppClient
    {
         Task<IList<string>> GetValues();
    }


    public class ApiAppClient : IApiAppClient
    {

        private readonly HttpClient httpClient;

        public ApiAppClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IList<string>> GetValues()
        {
            //Rest client implementation in Detail
            //https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/console-webapiclient
            // TO get json result back and convert to desried object type follow tutoria
            // Convert to list class anything you need 
            // Get string result back and get stream async back and convert to the format which you required

            httpClient.BaseAddress = new Uri("https://localhost:44310/api/values");
            var serializer = new DataContractJsonSerializer(typeof(List<string>));
            //var response = await this.httpClient.GetStringAsync("api/PdfCreator/PostPdfBytes", pdfDto).ConfigureAwait(false);
            var response2 = await this.httpClient.GetAsync(httpClient.BaseAddress);
            response2.EnsureSuccessStatusCode();
            var data = await this.httpClient.GetStreamAsync(httpClient.BaseAddress);
            IList<string> values = serializer.ReadObject(data) as List<string>;


            //var data = await response.Content.ReadAsStringAsync();

            //var response = await this.httpClient.GetStringAsync("api/PdfCreator/PostPdfBytes", pdfDto).ConfigureAwait(false

            //var response = await this.httpClient.GetStreamAsync(httpClient.BaseAddress);

            //var repositories = serializer.ReadObject( response) as List<string>; 
            //https://github.com/Devarsh14/DotNetCoreClientFactoryLearning/projects/1#card-14929918

            //List<string> strings = data;
            return values;

        }
    }
}
