using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using riwivet.Dto;
using riwivet.Models;
using riwivet.Services.Owners;

namespace riwivet.Controllers.Owners
{
    public class OwnerAddController : ControllerBase
    {
        private readonly IOwnersRepository _ownersRepository;

        public OwnerAddController(IOwnersRepository ownersRepository)
        {
            _ownersRepository = ownersRepository;
        }
        [HttpPost]
        [Route("/owners")]
        
        public async Task<IActionResult> CrearDueño([FromBody] OwnerDto owner)
        {
            var result = await _ownersRepository.add(owner);
            return Ok(result);
        }
       
    }
}