using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Dtos.Proveedor
{
    public class ProveedorUpdateDto
    {
        [Required]
        public int IdSupplier { get; set; }
        [Required, StringLength(100)]
        public string SupplierName { get; set; }
        //[Required, StringLength(100)]
        public string ContactName { get; set; }
        [Required, StringLength(100)]
        public string ContactTitle { get; set; }
        [Required, StringLength(100)]
        public string Phone { get; set; }
        [Required, StringLength(100)]
        public string Email { get; set; }
        [Required, StringLength(100)]
        public string Address { get; set; }
        [Required, StringLength(100)]
        public string City { get; set; }
        [Required, StringLength(100)]
        public string Country { get; set; }
        [Required, StringLength(100)]
        public string PostalCode { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime ModifiedDate { get; set; }
    }
}
