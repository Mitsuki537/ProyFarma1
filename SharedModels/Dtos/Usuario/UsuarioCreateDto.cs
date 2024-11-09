using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Dtos.Usuario
{
    public class UsuarioCreateDto
    {
        [Required,StringLength(100)]
        public string Username { get; set; }
        [Required,StringLength(100)]
        public string PasswordHash { get; set; }
        [Required]
        public int IdEmployee { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
