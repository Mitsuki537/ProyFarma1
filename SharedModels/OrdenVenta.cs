using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels
{
    public class OrdenVenta
    {
        public int IdSalesOrder { get; set; }
        public int IdCustomer { get; set; }
        public int IdEmployee { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
