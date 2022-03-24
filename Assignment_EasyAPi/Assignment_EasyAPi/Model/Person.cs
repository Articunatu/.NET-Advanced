using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_EasyAPi.Model
{
    public class Person
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Namn är ett krav")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Namnet måste vara mellan 3 och 20 bokstäver")]
        public string Name { get; set; }
        public string Class { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Typing Type1 { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Typing Type2 { get; set; }
    }

    public enum Typing
    {
        None, Grass, Fire, Water, Ice, Lightning, Air, Earth, Metal, Chemical, Space, Ray
    }
}
