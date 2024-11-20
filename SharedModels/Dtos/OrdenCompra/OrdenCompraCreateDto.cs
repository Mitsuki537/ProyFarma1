using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Dtos.OrdenCompra
{
    public class OrdenCompraCreateDto
    {
        [Required]
        public int IdSupplier { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; }
        [Required, StringLength(50)]
        public string Status { get; set; }
        public string? OrderNumber { get; set; }
    }
}
