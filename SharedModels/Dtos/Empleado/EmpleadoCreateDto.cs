using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Dtos.Empleado
{
    public class EmpleadoCreateDto
    {
        [Required, StringLength(100)]
        public string FirstName { get; set; }
        [Required, StringLength(100)]
        public string LastName { get; set; }
        [Required, StringLength(100)]
        public string Title { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime HireDate { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime? BirthDate { get; set; }
        [Required, StringLength(100)]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required, StringLength(100)]
        public string Department { get; set; }
        [Required]
        public int? ReportsTo { get; set; }
    }
}
