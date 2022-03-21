using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TesteSQLServer.Models {
    public class Payment {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }

        [JsonIgnore]
        public List<Order> Orders { get; set; }

    }
}
