using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HtttpClientFactoryProotype.Models;
using HtttpClientFactoryProotype.HttpClients;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;

namespace HtttpClientFactoryProotype.Controllers
{      [Authorize]
    public class HomeController : Controller
    {
        private readonly IApiAppClient apiAppClient;
        private readonly ILogger logger;
        public HomeController(IApiAppClient apiAppClient, ILogger<HomeController> logger)
        {
            this.apiAppClient = apiAppClient;
            this.logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            var strings=await this.apiAppClient.GetValues().ConfigureAwait(false);
            logger.LogInformation("output" + strings);

            logger.LogDebug("Debuggig output log");
            return View(strings);
        }
        public async Task Logout()
        {
            await HttpContext.SignOutAsync("Cookies");
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
