using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace FormMarket
{
    public class EFCUser
    {
        public int ID { get; set; } // первичный ключ
        public string? Username { get; set; } // прочие поля

        public string? Password { get; set; }

        public byte[]? ProfilePicture { get; set; }
        public string? Access { get; set; }
        public string? FilePath { get; set; }

        public EFCUser() 
        {
            Username = "unknown";
            Password = "unknown";
            Access = "customer";
        }

        public EFCUser(string username, string password)
        {
            Username = username;
            Password = password;
            Access = "customer";
        }

    }
}
