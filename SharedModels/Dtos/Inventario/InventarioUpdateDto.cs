using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Dtos.Inventario
{
    public class InventarioUpdateDto
    {
        public int IdProduct { get; set; }
        public int Quantity { get; set; }
        public DateTime DateReceived { get; set; }
    }
}
