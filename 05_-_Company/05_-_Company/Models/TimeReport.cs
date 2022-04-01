using System;
using System.ComponentModel.DataAnnotations;

namespace _05___Company_DB.Models
{
    public class TimeReport
    {
        [Key]
        public int? TR_ID { get; set; }
        public int? EmployeeID { get; set; }
        public int? ProjectID { get; set; }
        [Required(ErrorMessage = "Hur många timmar man har arbetat är avgörande för lönen!")]
        [Range(1,8)]
        public int Hours { get; set; }
        [Required(ErrorMessage = "Om inget datum anges kan lönen hamna på fel månad!")]
        public DateTime WeekDate { get; set; }
    }
}