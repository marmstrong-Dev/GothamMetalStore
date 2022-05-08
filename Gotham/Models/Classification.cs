using System;
using System.Collections.Generic;

namespace Gotham.Models
{
    public class Classification
    {
        public int id { get; set; }
        public string classificationTitle { get; set; }
        public string classificationDescription { get; set; }
        public virtual List<Metal> classifiedMetals { get; set; }
    }
}
