using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteSQLServer.DTOs {
    public class CreateFavoriteDto {
        public int ProductId { get; set; }
        public int UserId { get; set; }
    }
}
