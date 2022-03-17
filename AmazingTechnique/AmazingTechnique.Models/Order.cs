using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AmazingTechnique.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public DateTime OrderPlaced { get; set; }

        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
    }
}
