using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gotham.Tools
{
    public class QueryParameters
    {
        public int Page { get; set; }
        public string SortBy { get; set; } = "id";
        private string sortOrder = "asc";

        const int _maxSize = 100;
        private int _size = 50;

        // Property for determining page size for pagination
        public int Size
        {
            get
            { return _size; }
            set
            { _size = Math.Min(_maxSize, value); }
        }

        // Property for sorting either asc 'Ascending' or desc 'Descending'
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
