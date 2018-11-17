using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HtttpClientFactoryProotype
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //// Automapper (+ AutoMapper.Data to map SqlReaders to EF Models)
            //services.AddAutoMapper(cfg =>
            //{
            //    //cfg.AddDataReaderMapping();
            //    cfg.CreateMissingTypeMaps = true;
            //});


            // Add document Db
            //services.AddSingleton<IDocumentClient>(x => new DocumentClient(new Uri($"https://cosmosdb-devarsh-au-{this.HostingEnvironment.EnvironmentName.ToLower().Substring(0, 3)}.documents.azure.com:443/"), this.Configuration.GetValue<string>("CosmosDbRoutingKey")));

            //// Feature service
            //services.AddFeatureToggle();

            // Application insight telemetetry
            //services.AddApplicationInsightsTelemetry();

            //Bug: add Httpcclient confiugre and add json file.
            //services.AddHttpClient<PdfClient>(client => client.BaseAddress = new Uri(this.Configuration.GetSection("PdfConfiguration")["OversiPdfGeneratorHost"]));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}



//// This method gets called by the runtime.Use this method to configure the HTTP request pipeline.
//        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
//{
//    // First up - HTTPS only
//    app.UseHttpsRedirection();

//    // Add a single debug logger
//    loggerFactory.AddDebug();

//    bool.TryParse(this.Configuration.GetSection("Logging").GetValue<string>("LocalMode"), out bool localMode);

//    if (env.IsDevelopment() || localMode == true)
//    {
//        app.UseDeveloperExceptionPage();
//        app.UseDatabaseErrorPage();
//        //app.UseBrowserLink();
//    }
//    else
//    {
//        app.UseExceptionHandler("/Home/Error");
//        app.UseHsts();
//        loggerFactory.AddApplicationInsights(app.ApplicationServices, LogLevel.Information);
//    }
