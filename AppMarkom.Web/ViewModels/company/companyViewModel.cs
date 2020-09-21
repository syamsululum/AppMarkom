using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppMarkom.Web.ViewModels.company
{
    public class companyViewModel
    {
        public int Id { get; set; }
        public string Code        { get; set; }
        [RegularExpression(@"(.|\s)*\S(.|\s)*", ErrorMessage = "Name tidak boleh kosong")]
        public string Name        { get; set; }
        public string Address     { get; set; }
        [RegularExpression(@"(\+?([ -]?\d+)+|\(\d+\)([ -]\d+))", ErrorMessage = "Nomer tidak valid")]
        public string Phone       { get; set; }
        [EmailAddress(ErrorMessage = "Email tidak valid")]
        public string Email       { get; set; }
        public bool IsDelete    { get; set; }
        public string CreatedBy   { get; set; }
        
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy   { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
