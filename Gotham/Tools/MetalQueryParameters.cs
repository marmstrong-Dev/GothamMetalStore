using System;

namespace Gotham.Tools
{
    public class MetalQueryParameters : QueryParameters
    {
        public int? MinSize { get; set; }
        public int? MaxSize { get; set; }
        public string metalType { get; set; }
    }
}
