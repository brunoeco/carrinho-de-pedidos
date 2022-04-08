using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteSQLServer.DTOs
{
    public class ReadPaymentDto
    {
        [Required]
        public Guid Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
    }
}
