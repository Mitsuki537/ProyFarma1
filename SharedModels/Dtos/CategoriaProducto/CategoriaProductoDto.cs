﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Dtos.CategoriaProducto
{
    public class CategoriaProductoDto
    {
        public int IdCategory { get; set; }
        public int? IdParentCategory { get; set; }
        public string CategoryName { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}