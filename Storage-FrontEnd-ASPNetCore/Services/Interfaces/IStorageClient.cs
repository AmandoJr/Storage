using StorageModels.Models;
using System.Collections.Generic;

namespace Storage_FrontEnd_ASPNetCore.Services.Interfaces
{
    public interface IStorageClient
    {
        IEnumerable<ResultItem> Calculate(Item itemMovement);

        IEnumerable<ResultItem> GetMockResultItems();
    }
}