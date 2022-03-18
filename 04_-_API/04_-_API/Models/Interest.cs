using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _04___API.Models
{
    public class Interest
    {
        [Key]
        public int InterestID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<WebLink> WebLinks { get; set; }
    }
}
