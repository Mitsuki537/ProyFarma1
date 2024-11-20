using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Dtos.DetalleOrdenCompra
{
    public class DetalleOrdenCompraCreateDto
    {
        [Required]
        public int IdPurchaseOrder { get; set; }

        [Required]
        public int IdProduct { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal UnitPrice { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ReturnDeadline { get; set; }
        public string? OrderNumber { get; set; }
    }
}
