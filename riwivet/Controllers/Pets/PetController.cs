using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using riwivet.Models;
using riwivet.Services.Pets;

namespace riwivet.Controllers.Pets
{
   
    public class PetController : ControllerBase
    {
        private readonly IPetsRepository _petsRepository;
        public PetController(IPetsRepository petsRepository)
        {
            _petsRepository = petsRepository;
        }
        [HttpGet]
        [Route("/pets")]
        public IEnumerable<Pet> ListAll()
        {
            return _petsRepository.GetAllPets();
        }
        [HttpGet]
        [Route("/pets/{id}")]
        public Pet Get(int id)
        {
            return _petsRepository.GetById(id);
        } 

        [HttpGet]
        [Route("/pets/{date}/BirthDay")]
        public IEnumerable<Pet> GetBirt(DateTime date)
        {
            return _petsRepository.GetByBirth(date);
        }
        [HttpGet]
        [Route("/pets/{name}/owner")]
        public IEnumerable<Pet> getbyowners(string name)
        {
            return _petsRepository.GetByOwner(name);
        }
      
    }
}