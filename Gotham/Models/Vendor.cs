using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gotham.Models
{
    public class Vendor
    {
        [Key]
        public int id { get; set; }
        public string vendorName { get; set; }
        public string vendorCity { get; set; }
        public string vendorStateTerritory { get; set; }
        public string vendorCountry { get; set; }
        public virtual List<Order> vendorOrders { get; set; }
    }
}
