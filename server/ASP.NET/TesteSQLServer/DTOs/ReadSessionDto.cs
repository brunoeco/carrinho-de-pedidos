using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteSQLServer.DTOs {
    public class ReadSessionDto {
        public ReadUserDto User { get; set; }
        public string Token { get; set; }
    }
}
