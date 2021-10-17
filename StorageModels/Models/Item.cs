using System;

namespace StorageModels.Models
{
    public class Item
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal UnitValue { get; set; }
        public Enums.Action Action { get; set; }
    }
}
