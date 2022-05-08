using System;
using System.Collections.Generic;

namespace Gotham.Models
{
    public class Metal
    {
        public int id { get; set; }
        public string metalType { get; set; }
        public int metalBundleSize { get; set; }
        public DateTime lastOrdered { get; set; }
    }
}
