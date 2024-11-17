using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Dtos.MovimientoInventario
{
    public class MovimientoInventarioDto
    {
        public int IdMovement { get; set; }
        public int IdInventory { get; set; }
        public string MovementType { get; set; }
        public int Quantity { get; set; }
        public DateTime MovementDate { get; set; }
        public int? ReferenceID { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
