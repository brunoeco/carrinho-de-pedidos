using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteSQLServer.DTOs {
    public class CreateFavoriteDto {
        [Required]
        public Guid ProductId { get; set; }
    }
}
