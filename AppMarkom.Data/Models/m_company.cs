using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppMarkom.Data.Models
{
    public class m_company
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Code { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Address { get; set; }
        [MaxLength(50)]
        public string Phone { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        public bool IsDelete { get; set; }
        [MaxLength(50)]
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [MaxLength(50)] public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
