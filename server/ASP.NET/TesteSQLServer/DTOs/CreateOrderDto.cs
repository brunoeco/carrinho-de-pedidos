using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteSQLServer.DTOs {
    public class CreateOrderDto {
        public int UserId { get; set; }
        public int PaymentId { get; set; }
        public CreateAddressDto Address { get; set; }
        public CreateOrderItemDto[] OrderItems { get; set; }
    }
}
