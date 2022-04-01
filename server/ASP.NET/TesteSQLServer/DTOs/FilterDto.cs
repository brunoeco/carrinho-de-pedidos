using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteSQLServer.DTOs
{
    public class FilterDto
    {
        public string Category { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public string Search { get; set; }

        public FilterDto()
        {
            Category = "";
            MinPrice = 0;
            MaxPrice  = -1;
            Search = "";
        }
    }
}
