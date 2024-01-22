using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gotham.Models
{
    public class Classification
    {
        [Key]
        public int id { get; set; }
        public string classificationTitle { get; set; }
        public string classificationDescription { get; set; }
        public virtual List<Metal> classifiedMetals { get; set; }
    }
}
