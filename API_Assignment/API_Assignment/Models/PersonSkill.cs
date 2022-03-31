using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Assignment.Models
{
    public class PersonSkill
    {
        [Key]
        public int PS_ID { get; set; }
        [ForeignKey("Person")]
        public int PersonID { get; set; }
        [ForeignKey("Skill")]
        public int SkillID { get; set; }
    }
}
