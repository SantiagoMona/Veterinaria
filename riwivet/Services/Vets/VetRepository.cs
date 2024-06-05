using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using riwivet.Data;
using riwivet.Models;

namespace riwivet.Services.Vets
{
    public class VetRepository : IVetRepository
    {
        private readonly BaseContext _baseContext;
        public VetRepository(BaseContext baseContext)
        {
            _baseContext = baseContext;
        }
        /*===================== lISTAR ======================*/
        public IEnumerable<Vet> GetAllVets()
        {
            /*SE LISTAN TODOS LOS VETERINARIOS */
            return _baseContext.Vets.ToList(); 
        }

        public Vet GetById(int id)
        {
            /*SE BUSCA UN VETERINARIO POR SU ID */
            var VetExists = _baseContext.Vets.Find(id);
            if (VetExists == null)
            {
                throw new Exception("Veterinario no encontrado");
            }
            return VetExists;
        }
    }
}