using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace riwivet.Models
{
    public class Vet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email {get;set;}
        public string Address {get;set;}
        public string Phone {get;set;}
        
        [JsonIgnore]
        public List<Quote>? Quotes { get; set; } 
        

    }
}