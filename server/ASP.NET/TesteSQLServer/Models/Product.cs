using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TesteSQLServer.Models {
    public class Product {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        [MaxLength(20)]
        public string Category { get; set; }
        public decimal Price { get; set; }
        [MaxLength(30)]
        public string ImageUrl { get; set; }

        [JsonIgnore]
        public List<Favorite> Favorites { get; set; }
        [JsonIgnore]
        public List<OrderItem> OrderItems { get; set; }
    }
}
