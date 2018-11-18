using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtttpClientFactoryProotype.HttpClients;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.Logging;



//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.IdentityModel.Tokens.Jwt;
//using System.Linq;
//using System.Reflection;
//using AutoMapper;
//using DinkToPdf;
//using DinkToPdf.Contracts;
//using FluentValidation;
//using FluentValidation.AspNetCore;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Authentication.OpenIdConnect;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//// added for form size limits
//using Microsoft.AspNetCore.Http.Features;
//using Microsoft.AspNetCore.Localization;
//using Microsoft.AspNetCore.Mvc.Authorization;
//using Microsoft.AspNetCore.Mvc.Infrastructure;
//using Microsoft.AspNetCore.Mvc.Razor;
//using Microsoft.AspNetCore.Routing.Constraints;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Logging;
//using Microsoft.IdentityModel.Tokens;
//using NETCore.MailKit.Extensions;
//using NETCore.MailKit.Infrastructure.Internal;
//using Newtonsoft.Json;
//// added these to prevent recursive loop issue
//using Newtonsoft.Json.Serialization;
//using OversiWeb.Areas.Actions.Services;
//using OversiWeb.Areas.Risks.Models.RisksViewModels;
//using OversiWeb.Authorizations;
//using OversiWeb.Extensions;
//using OversiWeb.Helpers;
//using OversiWeb.Models;
//using OversiWeb.Services;
//using System.Security.Cryptography.X509Certificates;
//using Microsoft.Azure.Services.AppAuthentication;
//using Microsoft.AspNetCore.DataProtection;
//using StackExchange.Redis;
//using AutoMapper.Data;
//using OversiWeb.TagHelpers;
//using System.Data;
//using Microsoft.AspNetCore.HttpOverrides;
//using OversiWeb.Configuration;
//using Microsoft.AspNetCore.Http;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.Azure.KeyVault;
//using OversiWeb.Areas.Contacts.Models.ContactsViewModels;
//using OversiWeb.Data;
//using OversiWeb.Cache;
//using OversiWeb.HttpClients;
//using Microsoft.Azure.Documents;
//using Microsoft.Azure.Documents.Client;

namespace HtttpClientFactoryProotype
{
    public class Startup
    {

        //public Startup(IHostingEnvironment env, IHttpContextAccessor httpContextAccessor)
        //{
        //    var builder = new ConfigurationBuilder()
        //        .SetBasePath(env.ContentRootPath)
        //        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        //        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

        //    if (env.IsDevelopment() || env.IsEnvironment("Integration"))
        //    {
        //        // For more details on using the user secret store see https://go.microsoft.com/fwlink/?LinkID=532709
        //        // builder.AddUserSecrets<Startup>();
        //    }

        //    builder.AddEnvironmentVariables();

        //    this.Configuration = builder.Build();

        //    // Connect to KVS using MSI (needs config value for the vault)
        //    builder.AddAzureKeyVault(Program.GetKeyVaultEndpoint(env.EnvironmentName));

        //    // Rebuild the configuration
        //    this.Configuration = builder.Build();

        //    this.HttpContextAccessor = httpContextAccessor;
        //    this.HostingEnvironment = env;
        //}

        //public IConfigurationRoot Configuration { get; }
        //public IHttpContextAccessor HttpContextAccessor { get; }
        //public IHostingEnvironment HostingEnvironment { get; set; }

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


            //// Use HTTPS (use default in non-local environments)
            //if (this.HostingEnvironment.EnvironmentName == "Development")
            //{
            //    services.AddHttpsRedirection(options => options.HttpsPort = 44337);
            //}

            //// HSTS - https://blogs.msdn.microsoft.com/webdev/2018/02/27/asp-net-core-2-1-https-improvements/
            //services.AddHsts(options =>
            //{
            //    options.MaxAge = TimeSpan.FromDays(100);
            //    options.IncludeSubDomains = true;
            //    options.Preload = true;
            //});

            //JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            //// Add configuration services //
            //services.AddSingleton(provider => this.Configuration);


            //services.AddAuthentication(options =>
            //{

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            //})
            //    .AddCookie(options =>
            //    {
            //        options.Cookie.HttpOnly = true;
            //        options.Cookie.Name = "OversiAppCookie";
            //        options.AccessDeniedPath = new PathString("/Account/AccessDeniedNoRoute");
            //        // This will be taken care of by Identity
            //        options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None;
            //    })
            //    .AddJwtBearer()
            //    .AddOpenIdConnect(options =>
            //    {
            //        options.RequireHttpsMetadata = this.HostingEnvironment.IsProduction();
            //        options.GetClaimsFromUserInfoEndpoint = true;
            //        options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            //        // Create a handler for the host/signin-oidc page
            //        options.Events.OnRemoteFailure = this.RemoteAuthFail;

            //        options.Authority = this.Configuration.GetSection("IdentityConfiguration")["OversiIdentityServerHost"];
            //        options.ClientId = this.Configuration.GetSection("IdentityConfiguration")["ClientId"];
            //        options.ClientSecret = this.Configuration.GetSection("IdentityConfiguration")["ClientSecret"];

            //        options.ResponseType = "code id_token";
            //        options.SaveTokens = true;

            //        options.TokenValidationParameters = new TokenValidationParameters() { NameClaimType = "email" };
            //        options.UseTokenLifetime = true;

            //        options.Scope.Add("webappapi");
            //        options.Scope.Add("offline_access");
            //        options.Scope.Add("openid");
            //        options.Scope.Add("email");
            //        options.Scope.Add("profile");
            //        options.Scope.Add("defaulttenant");
            //        options.Scope.Add("allowedtenant");
            //    });

            //// Attempt to allow JS AJAX calls after a deployment occurs
            //services.AddCors();

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowSpecificOrigin",
            //        builder => builder.WithOrigins(this.Configuration.GetSection("IdentityConfiguration")["PortalWebUrl"]).AllowAnyHeader().AllowAnyMethod());
            //});
            // add routing services and understand what problem routing services solves 

            //// Add Tenant DB contexts //
            //services.AddDbContext<DevarshDbContext>();
            //services.AddDbContext<DevarshNoteDbContext>();
            //services.AddDbContext<DevarshFileAttachmentDbContext>();
            //services.AddDbContext<DevarshAuditDbContext>();

            //services.AddEntityFrameworkSqlServer()
            //    .AddDbContext<DevarshRefDbContext>(options =>
            //    {
            //        options.UseSqlServer(
            //            this.Configuration.GetConnectionString("DevarshAppRefDbConnection"),
            //            sqlServerOptionsAction: sqlOptions =>
            //            {
            //                sqlOptions.EnableRetryOnFailure(
            //                    maxRetryCount: 5,
            //                maxRetryDelay: TimeSpan.FromSeconds(30),
            //                errorNumbersToAdd: null);
            //            });
            //    });


            // Large forms were not submitting with the defaul of 1024 objects //
            //services.Configure<FormOptions>(x => x.ValueCountLimit = 32768);

            //// Add messaging services
            //services.AddTransient<IEmailSender, AuthMessageSender>();
            //services.AddTransient<ISmsSender, AuthMessageSender>();
            //services.AddSingleton<IMessageConfiguration>(this.Configuration.GetSection("MessageConfiguration").Get<MessageConfiguration>());

            // Redis  // than learn mongo db

            // Add the cache and data protection keys
            //bool.TryParse(this.Configuration.GetSection("Logging").GetValue<string>("LocalMode"), out bool localMode);
            //string cacheConnectiontString = this.Configuration["RedisConnection"];
            //if (localMode)
            //{
            //    cacheConnectiontString = "localhost";
            //}

            //services.AddDistributedRedisCache(options =>
            //{
            //    options.Configuration = "connectTimeout=10000,syncTimeout=10000," + cacheConnectiontString;
            //    options.InstanceName = "master";
            //});

            //ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("syncTimeout=5000," + cacheConnectiontString);

            //AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider();
            //KeyVaultClient keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
            //services.AddDataProtection()
            //    .PersistKeysToRedis(redis, "DataProtection-Keys")
            //    .ProtectKeysWithAzureKeyVault(keyVaultClient, $"https://KVS-Devarsh-{this.HostingEnvironment.EnvironmentName.ToUpper().Substring(0, 3)}.vault.azure.net/keys/AppDPKey")
            //    .SetApplicationName("Devarsh");


            // Azure cahing look at https://docs.microsoft.com/en-us/azure/architecture/best-practices/caching
            //services.AddSingleton<IAzureCacheStorage>(factory =>
            //{
            //    return new AzureCacheStorage(new AzureCacheSettings(
            //        connectionString: cacheConnectiontString));
            //});



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

            // Microsoft.extention ==> is important to understand what technologies are comming as DI or the new extentions are added. 

            services.AddHttpClient<IApiAppClient, ApiAppClient>();

            //Bug: add Httpcclient confiugre and add json file.
            //services.AddHttpClient<PdfClient>(client => client.BaseAddress = new Uri(this.Configuration.GetSection("PdfConfiguration")["DevarshPdfGeneratorHost"]));

            services.AddLogging();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging")); // Log level is set in configuraiton file. YOu can set manully over here as weell.
                                                                           //Configuration.GetSection("Logging")
            loggerFactory.AddDebug(LogLevel.Trace);
            

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
