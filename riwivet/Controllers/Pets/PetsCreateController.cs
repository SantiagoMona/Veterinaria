using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using riwivet.Dto;
using riwivet.Models;
using riwivet.Services.Pets;

namespace riwivet.Controllers.Pets
{
    
    public class PetsCreateController : ControllerBase
    {
        private readonly IPetsRepository _petsRepository;
        public PetsCreateController(IPetsRepository petsRepository)
        {
            _petsRepository = petsRepository;
        }
        [HttpPost]
        [Route("/pets")]
        public async Task<IActionResult> CrearMascota([FromBody] PetDto petDto )
        {
            var Newpet = await _petsRepository.add(petDto);
            return Ok(Newpet);
        }
    }
}