using System.ComponentModel.DataAnnotations;

namespace _05___Company_DB.Models
{
    public class Project
    {
        [Key]
        public int ProjectID { get; set; }
        [Required(ErrorMessage = "Ett projekt måste ha en titel!"), ]
        [StringLength(20, ErrorMessage = "Ett projekts titel kan ej vara längre än 22 bokstäver långt!")]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
