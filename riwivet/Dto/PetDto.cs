using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace riwivet.Dto
{
    public class PetDto
    {
        public string Name { get; set; }
        public string Specie { get; set; }
        public string Race { get; set; }
        public string Photo { get; set; }
        public DateTime DateBirth { get; set; }
        public int OwnerId { get; set; }
    }
}