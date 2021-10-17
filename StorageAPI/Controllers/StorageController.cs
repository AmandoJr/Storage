using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StorageAPI.Enums;
using StorageAPI.Services.Interfaces;
using StorageModels.Models;
using System;
using System.Collections.Generic;

namespace StorageAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StorageController : ControllerBase
    {
        private readonly ILogger<StorageController> _logger;
        private readonly IStorageService _storageService;

        public StorageController(ILogger<StorageController> logger, IStorageService storageService)
        {
            if (storageService is null)
            {
                throw new ArgumentNullException(nameof(storageService));
            }

            _logger = logger;

            this._storageService = storageService;
        }

        [HttpPost]
        public IEnumerable<ResultItem> Calculate(Mode mode, IEnumerable<Item> items)
        {
            switch (mode)
            {

                case Mode.Fifo:
                    return _storageService.DoFifo(items);
                case Mode.Lifo:
                    return _storageService.DoLifo(items);
                case Mode.Average:
                    return _storageService.DoAverage(items);
                default:
                    throw new Exception("Mode not supported");
            }

            throw new Exception("Unable to Calculate");
        }


        [HttpGet]
        public IEnumerable<ResultItem> GetMockResultItems()
        {
            return new ResultItem[]
            {
                new ResultItem { Name = "Some Item 1", Quantity = 10, UnitValue = 10.0M },
                new ResultItem { Name = "Some Item 2", Quantity = 15, UnitValue = 15.0M },
                new ResultItem { Name = "Some Item 3", Quantity = 20, UnitValue = 20.0M },
                new ResultItem { Name = "Some Item 4", Quantity = 25, UnitValue = 25.0M },
                new ResultItem { Name = "Some Item 5", Quantity = 30, UnitValue = 30.0M },
            };
        }
    }
}
