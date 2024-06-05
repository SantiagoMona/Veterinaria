using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using riwivet.Dto;
using riwivet.Services.Pets;

namespace riwivet.Controllers.Pets
{
    
    public class PetUpdateController : ControllerBase
    {
        private readonly IPetsRepository _petsRepository;
        public PetUpdateController(IPetsRepository pets)
        {
            _petsRepository = pets;
        }
        [HttpPut]
        [Route("/pets/{id}")]
         public async Task<IActionResult> updatepet(int id, [FromBody] PetDto PetsDto)
        {
            var result = await _petsRepository.UptadePet(id, PetsDto);
            return Ok(result);
        }
       
    }
}