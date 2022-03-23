using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TesteSQLServer.Models {
    public class Product {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
        [MaxLength(20)]
        [Required]
        public string Category { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [MaxLength(30)]
        public string ImageUrl { get; set; }

        [JsonIgnore]
        public List<Favorite> Favorites { get; set; }
        [JsonIgnore]
        public List<OrderItem> OrderItems { get; set; }
    }
}
