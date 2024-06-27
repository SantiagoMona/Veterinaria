using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using riwivet.Data;
using riwivet.Models;

namespace riwivet.Services.Vets
{
    public class VetRepository : IVetRepository
    {
        private readonly BaseContext _baseContext;
        private readonly IConfiguration _configuration;
        public VetRepository(BaseContext baseContext, IConfiguration configuration)
        {
            _baseContext = baseContext;
        }

        public string generateToken(string correo, string codigo)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var credentials = new SigningCredentials(securitykey,SecurityAlgorithms.HmacSha256); 

            var claims = new List<Claim>{
                new Claim(ClaimTypes.NameIdentifier,codigo),
                new Claim(JwtRegisteredClaimNames.Sub,correo),
                new Claim(JwtRegisteredClaimNames.Sub, Guid.NewGuid().ToString()),
            };
            var token = new JwtSecurityToken(
                issuer : _configuration["Jwt: Issuer"],
                audience : _configuration["Jwt:Audience"],
                claims:claims,
                expires : DateTime.Now.AddMinutes(150),
                signingCredentials : credentials
                
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
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