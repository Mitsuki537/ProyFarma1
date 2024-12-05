using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels
{
    public class DetalleOrdenCompra
    {
        public int IdPurchaseOrderDetail { get; set; }
        public int IdPurchaseOrder { get; set; }
        public int IdProduct { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime? ReturnDeadline { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string?  OrderNumber { get; set; }
    }
}
