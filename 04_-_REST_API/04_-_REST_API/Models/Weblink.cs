using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _04___REST_API.Models
{
    public class Weblink
    {
        [Key]
        public int? WebID { get; set; }
        public string LinkURL { get; set; }

        public int? PersonID { get; set; }

        public int? InterestID { get; set; }
    }
}
