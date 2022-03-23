using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteSQLServer.DTOs {
    public class CreateOrderDto {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int PaymentId { get; set; }
        public CreateAddressDto Address { get; set; }
        public CreateOrderItemDto[] OrderItems { get; set; }
    }
}
