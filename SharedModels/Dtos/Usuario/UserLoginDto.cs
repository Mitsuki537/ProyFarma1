﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Dtos.Usuario
{
    public class UserLoginDto
    {
        [Required, StringLength(50)]
        public string Username { get; set; }

        [Required, StringLength(50)]
        public string Password { get; set; }
    }
}
