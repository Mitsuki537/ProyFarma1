using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Dtos.Usuario
{
    public class UsuarioCreateDto
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public int IdEmployee { get; set; }
        public string Role { get; set; }
    }
}
