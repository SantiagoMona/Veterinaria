using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using riwivet.Dto;
using riwivet.Services.Owners;

namespace riwivet.Controllers.Owners
{
    public class OwnerUpdateController : ControllerBase
    {
         private readonly IOwnersRepository _ownersRepository;

        public OwnerUpdateController(IOwnersRepository ownersRepository)
        {
            _ownersRepository = ownersRepository;
        }
        [HttpPut]
        [Route("/owners/{id}")]
        public async Task<IActionResult> UpdateOwner(int id, [FromBody] OwnerDto ownerDto)
        {
            var result = await _ownersRepository.UptadeOwner(id, ownerDto);
            return Ok(result);
        }

    }
}