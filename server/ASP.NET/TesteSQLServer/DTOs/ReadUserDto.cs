using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteSQLServer.DTOs {
    public class ReadUserDto {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string username { get; set; }
    }
}
