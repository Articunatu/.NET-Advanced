using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace AmazingTechnique.Models
{
    [Serializable]
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public DateTime OrderPlaced { get; set; }

        [JsonIgnore]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
    }
}
