using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels
{
    public class OrdenCompra
    {
        public int IdPurchaseOrder { get; set; }
        public int IdSupplier { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
