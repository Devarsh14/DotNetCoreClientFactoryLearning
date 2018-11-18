using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HtttpClientFactoryProotype.Models;
using HtttpClientFactoryProotype.HttpClients;

namespace HtttpClientFactoryProotype.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApiAppClient apiAppClient;
        public HomeController(IApiAppClient apiAppClient)
        {
            this.apiAppClient = apiAppClient;
        }
        public async Task<IActionResult> Index()
        {
            var strings=await this.apiAppClient.GetValues().ConfigureAwait(false);
            return View(strings);
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
