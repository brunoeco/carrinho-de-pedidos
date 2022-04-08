using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TesteSQLServer.Models;

namespace TesteSQLServer.DTOs {
    public class ReadOrderDto {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid PaymentId { get; set; }
        public DateTime CreatedAt { get; set; }

        public ReadPaymentDto Payment { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public ReadAddressDto Address { get; set; }
        public List<ReadOrderItemDto> OrderItems { get; set; }
    }
}
