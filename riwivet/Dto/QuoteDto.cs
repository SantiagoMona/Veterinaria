using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace riwivet.Dto
{
    public class QuoteDto
    {
        public DateTime Data { get; set; }
        public string Description  { get; set; } 
        public int PetId { get; set; }
        public int VetId { get; set; }
    }
}