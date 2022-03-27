using System.ComponentModel.DataAnnotations;

namespace _04___REST_API.Models
{
    public class Interest
    {
        [Key]
        public int InterestID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
