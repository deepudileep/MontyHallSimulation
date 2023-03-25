using Microsoft.AspNetCore.Mvc;
using MontyHallSimulation.Service;
using MontyHallSimulation.Models;
using System.Diagnostics;

namespace MontyHallSimulation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IMontyHallServices service;

        public HomeController(ILogger<HomeController> logger, IMontyHallServices service)
        {
            this.logger = logger;
            this.service = service;
        }

        public IActionResult Index()
        {
            MontyHallResponseModel montyHallResponseModel = new MontyHallResponseModel();
            return View(montyHallResponseModel);
        }

        [HttpPost]
        public IActionResult Index(MontyHallResponseModel montyHallResponseModel)
        {
            try
            {
                if (montyHallResponseModel.NoOfSimulation > 0)
                {
                    montyHallResponseModel = this.service.MontyHallCalculation(montyHallResponseModel);
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error Occured:-", ex);
            }
            return View(montyHallResponseModel);
        }
    }
}