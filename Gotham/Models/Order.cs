using System;

namespace Gotham.Models
{
    public class Order
    {
        public int id { get; set; }
        public DateTime orderTime { get; set; }
        public Metal orderedMetal { get; set; }
        public int orderBatchQuantity { get; set; }
        public Vendor orderVendor { get; set; }
    }
}
