using Microsoft.VisualStudio.TestTools.UnitTesting;
using StorageAPI.Services;
using StorageAPI.Services.Interfaces;
using StorageModels.Models;
using System.Linq;

namespace StorageAPI.Tests
{
    [TestClass]
    public class StorageServiceTests
    {
        private const string _itemName = "ItemName";

        public IStorageService StorageService { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            StorageService = new StorageService();
        }

        [TestMethod]
        public void StorageService_DoFifo()
        {
        }

        [TestMethod]
        public void StorageService_DoLifo()
        {
        }

        [TestMethod]
        public void StorageService_DoAverage_Zero()
        {
            var initialItems = new Item[]
            {
                new Item () { Name = _itemName, Quantity = 10, UnitValue = 10, Action = StorageModels.Enums.Action.Add },
                new Item () { Name = _itemName, Quantity = 10, UnitValue = 10, Action = StorageModels.Enums.Action.Remove }
            };

            var result = StorageService.DoAverage(initialItems);

            Assert.AreEqual(0, result.FirstOrDefault().Quantity);
            Assert.AreEqual(0, result.FirstOrDefault().UnitValue);
        }

        [TestMethod]
        public void StorageService_DoAverage_OneItem()
        {
            var initialItems = new Item[]
            {
                new Item () { Name = _itemName, Quantity = 10, UnitValue = 10, Action = StorageModels.Enums.Action.Add }
            };

            var result = StorageService.DoAverage(initialItems);

            Assert.AreEqual(10, result.FirstOrDefault().Quantity);
            Assert.AreEqual(10, result.FirstOrDefault().UnitValue);
        }

        [TestMethod]
        public void StorageService_DoAverage_MultipleItem()
        {
            var initialItems = new Item[]
            {
                new Item () { Name = _itemName, Quantity = 10, UnitValue = 10, Action = StorageModels.Enums.Action.Add },
                new Item () { Name = _itemName, Quantity = 5, UnitValue = 10, Action = StorageModels.Enums.Action.Add },
                new Item () { Name = _itemName, Quantity = 5, UnitValue = 10, Action = StorageModels.Enums.Action.Remove },
            };

            var result = StorageService.DoAverage(initialItems);

            Assert.AreEqual(10, result.FirstOrDefault().Quantity);
            Assert.AreEqual(10, result.FirstOrDefault().UnitValue);
        }

        [TestMethod]
        public void StorageService_DoAverage_MultipleItem2()
        {
            var initialItems = new Item[]
            {
                new Item () { Name = _itemName, Quantity = 10, UnitValue = 10, Action = StorageModels.Enums.Action.Add },
                new Item () { Name = _itemName, Quantity = 5, UnitValue = 5, Action = StorageModels.Enums.Action.Add },
                new Item () { Name = _itemName, Quantity = 5, UnitValue = 10, Action = StorageModels.Enums.Action.Remove },
            };

            var result = StorageService.DoAverage(initialItems);

            Assert.AreEqual(10, result.FirstOrDefault().Quantity);
            Assert.AreEqual((decimal)8.33, result.FirstOrDefault().UnitValue);
        }
    }
}

