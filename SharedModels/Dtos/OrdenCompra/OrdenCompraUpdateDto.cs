using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Dtos.OrdenCompra
{
    public class OrdenCompraUpdateDto
    {
        public int IdSupplier { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
    }
}
