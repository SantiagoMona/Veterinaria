using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using riwivet.Models;
using riwivet.Services.Owners;

namespace riwivet.Controllers.Owners
{
    public class OwnerController : ControllerBase
    {
        private readonly IOwnersRepository _ownersRepository;

        public OwnerController(IOwnersRepository ownersRepository)
        {
            _ownersRepository = ownersRepository;
        }
        [HttpGet]
        [Route("/owners")]
        public IEnumerable<Owner> ListAll()
        {
            return _ownersRepository.GetAllOwners();
        }
        [HttpGet]
        [Route("/owners/{id}")]
        public Owner Get(int id)
        {
            return _ownersRepository.GetById(id);
        }  
    }
}