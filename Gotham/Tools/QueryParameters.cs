using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gotham.Tools
{
    public class QueryParameters
    {
        public int page { get; set; }
        public string sortBy { get; set; } = "id";
        private string sortOrder = "asc";

        const int _maxSize = 100;
        private int _size = 50;

        public int Size
        {
            get
            { return _size; }
            set
            { _size = Math.Min(_maxSize, value); }
        }

        public string SortOrder
        {
            get
            { return sortOrder; }
            set
            {
                if (value == "asc" || value == "desc")
                { sortOrder = value; }
            }
        }
    }
}
