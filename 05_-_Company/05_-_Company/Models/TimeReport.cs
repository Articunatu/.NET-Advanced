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
        public int Hours { get; set; }
        public DateTime WeekDate { get; set; }
    }
}
