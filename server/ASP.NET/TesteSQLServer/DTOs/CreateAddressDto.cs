using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteSQLServer.DTOs {
    public class CreateAddressDto {
        [Required]
        [MaxLength(200)]
        public string Street { get; set; }
        [Required]
        [MaxLength(150)]
        public string District { get; set; }
        [Required]
        [MaxLength(150)]
        public string City { get; set; }
        [Required]
        [MaxLength(2)]

        public string State { get; set; }
        [Required]
        [MaxLength(8)]
        public string ZipCode { get; set; }
    }
}
