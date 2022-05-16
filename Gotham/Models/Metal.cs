using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Gotham.Models
{
    public class Metal
    {
        public int id { get; set; }
        public string metalType { get; set; }
        public int metalBundleSize { get; set; }
        public int bundlesOnHand { get; set; }
        public DateTime lastOrdered { get; set; }
        public int classificationId { get; set; }
        [JsonIgnore]
        public virtual Classification metalClassification { get; set; }
        public virtual List<Order> metalOrders { get; set; }
    }
}
