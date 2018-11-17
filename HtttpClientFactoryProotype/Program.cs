using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace HtttpClientFactoryProotype
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}

// Task How to use keyvalut url 


//public static IWebHost BuildWebHost(string[] args) =>
//    WebHost.CreateDefaultBuilder(args)
//        .UseApplicationInsights()
//        .UseDefaultServiceProvider((context, options) =>
//        {
//            options.ValidateScopes = !context.HostingEnvironment.IsProduction();

//                    // Workaround till they fix this https://github.com/aspnet/Home/issues/2737
//                    var type = options.GetType();
//            var propertyInfo = type.GetProperty("Mode", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
//            propertyInfo.SetValue(options, 1); // SET TO RUNTIME
//                })
//        .ConfigureAppConfiguration((hostingContext, builder) =>
//        {
//            var env = hostingContext.HostingEnvironment;
//            var keyVaultEndpoint = GetKeyVaultEndpoint(env.EnvironmentName);
//            if (!string.IsNullOrEmpty(keyVaultEndpoint))
//            {
//                var azureServiceTokenProvider = new AzureServiceTokenProvider();
//                var keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
//                builder.AddAzureKeyVault(keyVaultEndpoint, keyVaultClient, new DefaultKeyVaultSecretManager());
//            }
//        })
//        .UseStartup<Startup>()
//        .Build();
////Key valut uerl
//public static string GetKeyVaultEndpoint(string environmentName) => $"https://KVS-Devarsh-{environmentName.ToUpper().Substring(0, 3).ToString()}.vault.azure.net";