using AppMarkom.Data.Models;
using AppMarkom.Web.ViewModels.company;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppMarkom.Web.ViewModels.employee
{
    public class employeeViewModel
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Code { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        public companyViewModel MCompany { get; set; }
        [MaxLength(150)]
        public string Email { get; set; }
        [Required]
        public bool IsDelete { get; set; }
        [MaxLength(50)]
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
