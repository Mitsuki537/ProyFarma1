using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Dtos.OrdenVenta
{
    public class OrdenVentaCreateDto
    {
        public int IdCustomer { get; set; }
        public int IdEmployee { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
