using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using riwivet.Models;
using riwivet.Services.Vets;

namespace riwivet.Controllers.Vets
{
    public class VetController : ControllerBase
    {
        private readonly IVetRepository _VetsRepository;

        public VetController(IVetRepository VetsRepository)
        {
            _VetsRepository = VetsRepository;
        }
        [HttpGet]
        [Route("/Vets")]
        public IEnumerable<Vet> ListAll()
        {
            return _VetsRepository.GetAllVets();
        }
        [HttpGet]
        [Route("/Vets/{id}")]
        public Vet Get(int id)
        {
            return _VetsRepository.GetById(id);
        }  
    }
}