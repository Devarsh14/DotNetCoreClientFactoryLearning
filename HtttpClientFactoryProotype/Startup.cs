﻿using System;
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


            //// Make sessions expire after 10 mins //
            //services.AddSession(options =>
            //{
            //    options.Cookie.HttpOnly = true;
            //    options.Cookie.Name = ".ASPNetCoreSession";
            //    options.Cookie.Path = "/";
            //    options.IdleTimeout = TimeSpan.FromMinutes(599); // 1 minute less than Id token life
            //});

            //// Define security policies here
            //services.AddAuthorization(options =>
            //{
            //    foreach (var policyField in permissionFields)
            //    {
            //        options.AddPolicy((string)policyField.GetValue(null), policy => policy.Requirements.Add(new CustomAuthRequirement((string)policyField.GetValue(null))));
            //    }
            //});


            // ------------ //
            // LOCALISATION //
            // ------------ //
            //services.AddLocalization(options =>
            //{
            //    options.ResourcesPath = "Resources";
            //});

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);



            // Use serialisation settings fro MVC

            //JSON serialisation //
            //services.AddMvc(config =>
            //{
            //    var policy = new AuthorizationPolicyBuilder()
            //                     .RequireAuthenticatedUser()
            //                     .Build();
            //    config.Filters.Add(new AuthorizeFilter(policy));
            //}).AddJsonOptions(options =>
            //{
            //    options.SerializerSettings.ContractResolver = new DefaultContractResolver(); // Don't use Camel - it breaks Teleriks JSON response linking
            //    options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
            //    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; // .Ignore; // Allows Entity Framework to work without looking back up on itself
            //    options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc; // Attempt at making datetime work
            //})
            //.AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
            //.AddDataAnnotationsLocalization() // To dynamically name fields
            //.AddControllersAsServices()
            //.AddFluentValidation();


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
