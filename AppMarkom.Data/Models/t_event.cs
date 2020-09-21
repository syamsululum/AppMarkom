using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppMarkom.Data.Models
{
    public class t_event
    {
        [MaxLength(11)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Code { get; set; }
        [Required]
        [MaxLength(255)]
        public string EventName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [MaxLength(255)]
        public string Place { get; set; }
        [MaxLength(50)]
        public long Budget { get; set; }
        [Required]
        [MaxLength(11)]
        public int RequestBy { get; set; }
        [Required]
        public DateTime RequestDate { get; set; }
        [MaxLength(11)]
        public int ApprovedBy { get; set; }
        public DateTime ApprovedDate { get; set; }
        [MaxLength(11)]
        public int AssignTo { get; set; }
        public DateTime CloseDate { get; set; }
        [MaxLength(255)]
        public string Note { get; set; }
        [MaxLength(1)]
        public int Status { get; set; }
        [MaxLength(255)]
        public string RejectReason { get; set; }
        public bool IsDelete { get; set; }
        [MaxLength(50)]
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        [MaxLength(50)]
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
