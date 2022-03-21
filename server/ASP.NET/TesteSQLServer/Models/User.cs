using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TesteSQLServer.Models {
    public class User {
        public int id { get; set; }
        [MaxLength(50)]
        public string name { get; set; }
        [MaxLength(50)]
        public string email { get; set; }
        [MaxLength(20)]
        public string username { get; set; }
        [MaxLength(50)]
        public string password { get; set; }

        [JsonIgnore]
        public List<Order> Orders { get; set; }
        [JsonIgnore]
        public List<Favorite> Favorites { get; set; }
    }
}
