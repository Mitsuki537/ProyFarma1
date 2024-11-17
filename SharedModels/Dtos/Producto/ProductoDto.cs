using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Dtos.Producto
{
    public class ProductoDto
    {
        public int IdProduct { get; set; }
        public string ProductName { get; set; }
        public int IdSupplier { get; set; }
        public int IdCategory { get; set; }
        public decimal UnitPrice { get; set; }
        public int? ReorderLevel { get; set; }
        public string LoteNumber { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
