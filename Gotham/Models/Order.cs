using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Gotham.Models
{
    public class Order
    {
        public int id { get; set; }
        public DateTime orderTime { get; set; }
        [JsonIgnore]
        public virtual Metal orderedMetal { get; set; }
        public int orderBatchQuantity { get; set; }
        [JsonIgnore]
        public virtual Vendor orderVendor { get; set; }
    }
}
