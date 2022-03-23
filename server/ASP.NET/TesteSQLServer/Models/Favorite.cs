﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TesteSQLServer.Models {
    public class Favorite {
        [Required]
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }

        [JsonIgnore]
        public User User { get; set; }
        public Product Product { get; set; }
    }
}
