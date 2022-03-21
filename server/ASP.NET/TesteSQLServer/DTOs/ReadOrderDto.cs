﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TesteSQLServer.Models;

namespace TesteSQLServer.DTOs {
    public class ReadOrderDto {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PaymentId { get; set; }
        public DateTime CreatedAt { get; set; }

        public Payment Payment { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public Address Address { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}