using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TesteSQLServer.Models {
    public class User {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }

        [JsonIgnore]
        public List<Order> Orders { get; set; }
        [JsonIgnore]
        public List<Favorite> Favorites { get; set; }
    }
}
