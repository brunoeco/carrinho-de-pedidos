using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TesteSQLServer.Models;

namespace TesteSQLServer.DTOs {
    public class ReadFavoriteDto {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }

        [JsonIgnore]
        public User User { get; set; }
        public Product Product { get; set; }
    }
}
