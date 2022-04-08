using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TesteSQLServer.Models {
    public class Order {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public Guid PaymentId { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }

        public Payment Payment { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public Address Address { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
