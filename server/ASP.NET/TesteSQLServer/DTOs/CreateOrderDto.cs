using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteSQLServer.DTOs {
    public class CreateOrderDto {
        [Required]
        public int PaymentId { get; set; }
        [Required]
        public CreateAddressDto Address { get; set; }
        [Required]
        public CreateOrderItemDto[] OrderItems { get; set; }
    }
}
