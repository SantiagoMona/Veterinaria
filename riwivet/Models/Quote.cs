using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace riwivet.Models
{
    public class Quote
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string? Description  { get; set; } 
        public int PetId { get; set; }
        public Pet? Pet { get; set; }
        public int VetId { get; set; }
        public Vet? Vet { get; set; }

    }
}