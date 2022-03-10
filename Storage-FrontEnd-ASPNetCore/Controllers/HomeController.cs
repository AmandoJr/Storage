using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Storage_FrontEnd_ASPNetCore.Models;
using Storage_FrontEnd_ASPNetCore.Services.Interfaces;
using StorageModels.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Storage_FrontEnd_ASPNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStorageClient _storageClient;

        public HomeController(ILogger<HomeController> logger, IStorageClient storageClient)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _storageClient = storageClient ?? throw new ArgumentNullException(nameof(storageClient));
        }

        public IActionResult Index()
        {
            return MockInitialize();
        }

        public IActionResult MockInitialize()
        {
            var result = _storageClient.GetMockResultItems();
            return View(result);
        }

        public IActionResult DoMovement(Item itemMovement)
        {
            var result = _storageClient.Calculate(itemMovement);
            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
