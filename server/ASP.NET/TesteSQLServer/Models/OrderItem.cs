using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TesteSQLServer.Models {
    public class OrderItem {
        [Required]
        public Guid Id { get; set; }
        [JsonIgnore]
        [Required]
        public Guid OrderId { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }

        [JsonIgnore]
        public Order Order { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }

    }
}
