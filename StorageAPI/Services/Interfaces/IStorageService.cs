using StorageModels.Models;
using System.Collections.Generic;

namespace StorageAPI.Services.Interfaces
{
    public interface IStorageService
    {
        public IEnumerable<ResultItem> DoFifo(IEnumerable<Item> items);
        public IEnumerable<ResultItem> DoLifo(IEnumerable<Item> items);
        public IEnumerable<ResultItem> DoAverage(IEnumerable<Item> items);
    }
}
