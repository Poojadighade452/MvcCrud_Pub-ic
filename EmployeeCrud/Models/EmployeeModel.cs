using Microsoft.EntityFrameworkCore.Diagnostics;
using NuGet.Common;
using System.ComponentModel.DataAnnotations;
using System.Net.Cache;

namespace EmployeeCrud.Models
{
    public class EmployeeModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
       
        [Range(20,55,ErrorMessage ="Please enter correct Number")]
        public  int Age
        {

            get; set;
                
         }
        [Required]
        [RegularExpression("^([0-9]{10})$",ErrorMessage ="Invalid Mobile Number")]
        public long ?PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string ?EmailAddress { get; set; }
       
    }
}
