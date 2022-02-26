using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AjaxCRUDApp.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "This Field is Required")]
        public string Name { get; set; }

        [MaxLength(11)]
        [Column(TypeName = "nvarchar(11)")]
        [Required(ErrorMessage ="This Field is Required")]
        public string ContactNumber { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "This Field is Required")]
        public string Address { get; set; }

        [DataType(DataType.Date)]
        public DateTime JoiningDate { get; set; }


    }
}
