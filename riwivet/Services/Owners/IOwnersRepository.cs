
using riwivet.Dto;
using riwivet.Models;

namespace riwivet.Services.Owners
{
    public interface IOwnersRepository
    {
        IEnumerable<Owner> GetAllOwners();  
        Owner GetById(int id); 
        Task <string> UptadeOwner(int id, OwnerDto pacienteDto);
        Task<string> add(OwnerDto pacienteDto); 
    }

}