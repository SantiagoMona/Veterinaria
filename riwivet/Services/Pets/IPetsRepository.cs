using riwivet.Dto;
using riwivet.Models;

namespace riwivet.Services.Pets
{
    public interface IPetsRepository
    {
        IEnumerable<Pet> GetAllPets();  
        Pet GetById(int id); 
        Task <string> UptadePet(int id, PetDto petDto);
        Task<string> add(PetDto petDto);
        IEnumerable<Pet> GetByBirth(DateTime date); 
        IEnumerable<Pet> GetByOwner(string owner); 
    }
}