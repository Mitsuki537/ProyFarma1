using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Dtos.DetalleOrdenVenta
{
    public class DetalleOrdenVentaDto
    {
        public int IdSalesOrderDetail { get; set; }
        public int IdSalesOrder { get; set; }
        public int IdProduct { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? Discount { get; set; }
        public decimal LineTotal { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
