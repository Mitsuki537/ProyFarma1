using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels
{
    public class Usuario
    {
        public int IdUser { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public int IdEmployee { get; set; }
        public string Role { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
