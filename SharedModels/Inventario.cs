﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels
{
    public class Inventario
    {
        public int IdInventory { get; set; }
        public int IdProduct { get; set; }
        public int Quantity { get; set; }
        public DateTime DateReceived { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}