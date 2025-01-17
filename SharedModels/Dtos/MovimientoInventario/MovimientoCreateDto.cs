﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Dtos.MovimientoInventario
{
    public class MovimientoCreateDto
    {
        public int IdInventory { get; set; }
        public string MovementType { get; set; }
        public int Quantity { get; set; }
        public DateTime MovementDate { get; set; }
        public int? ReferenceID { get; set; }
    }
}
