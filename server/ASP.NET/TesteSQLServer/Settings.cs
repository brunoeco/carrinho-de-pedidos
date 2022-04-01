using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteSQLServer {
    public static class Settings {
        public static string Secret = "chave-secreta-muito-bem-escolhida";

        public static byte[] SecretBytes() {
            return Encoding.ASCII.GetBytes(Settings.Secret);
        }
    }
}
