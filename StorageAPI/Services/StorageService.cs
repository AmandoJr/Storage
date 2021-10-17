using StorageAPI.Services.Interfaces;
using StorageModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageAPI.Services
{
    public class StorageService : IStorageService
    {
        public IEnumerable<ResultItem> DoAverage(IEnumerable<Item> items)
        {
            var subItems = items.GroupBy(x => x.Name);

            var result = new List<ResultItem>();
            foreach (var item in items)
            {
                var currentItem = result.FirstOrDefault(x => x.Name == item.Name);
                if(currentItem == null)
                {
                    currentItem = new ResultItem() { Name = item.Name };
                    result.Add(currentItem);
                }

                switch (item.Action)
                {
                    case StorageModels.Enums.Action.Add:
                        var currentTotalValue = currentItem.UnitValue * currentItem.Quantity;
                        currentTotalValue += item.Quantity * item.UnitValue;

                        currentItem.Quantity += item.Quantity;
                        currentItem.UnitValue = currentTotalValue / currentItem.Quantity;

                        currentItem.UnitValue = Math.Round(currentItem.UnitValue, 2);
                        break;

                    case StorageModels.Enums.Action.Remove:
                        currentItem.Quantity -= item.Quantity;

                        if(currentItem.Quantity == 0)
                        {
                            currentItem.UnitValue = 0;
                        }
                        break;

                    default:
                        throw new Exception("Invalid item action");
                }
            }

            return result;
        }

        public IEnumerable<ResultItem> DoFifo(IEnumerable<Item> items)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ResultItem> DoLifo(IEnumerable<Item> items)
        {
            throw new NotImplementedException();
        }
    }
}
