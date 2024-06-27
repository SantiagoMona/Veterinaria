
using riwivet.Models;

namespace riwivet.Services.Vets
{
    public interface IVetRepository
    {
        IEnumerable<Vet> GetAllVets();  
        Vet GetById(int id); 
        string generateToken(string correo, string codigo);
    }
}