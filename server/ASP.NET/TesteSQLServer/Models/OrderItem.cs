using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TesteSQLServer.Models {
    public class OrderItem {
        public int Id { get; set; }
        [JsonIgnore]
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        [JsonIgnore]
        public Order Order { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }

    }
}
