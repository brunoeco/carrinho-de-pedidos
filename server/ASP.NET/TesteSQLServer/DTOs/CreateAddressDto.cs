using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteSQLServer.DTOs {
    public class CreateAddressDto {
        [MaxLength(200)]
        public string Street { get; set; }
        [MaxLength(150)]
        public string District { get; set; }
        [MaxLength(150)]
        public string City { get; set; }
        [MaxLength(2)]

        public string State { get; set; }
        [MaxLength(8)]
        public string ZipCode { get; set; }
    }
}
