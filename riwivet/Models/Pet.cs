using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace riwivet.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specie { get; set; }
        public string Race { get; set; }
        public DateTime DateBirth { get; set; }
        public string Photo { get; set; }
        
        public int OwnerId { get; set; }
        public Owner? Owner { get; set; }
        
        [JsonIgnore]
        public List<Quote> Quote { get; set; } 

    }
}