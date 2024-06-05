using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.EntityFrameworkCore;
using riwivet.Data;
using riwivet.Dto;
using riwivet.Models;


namespace riwivet.Services.Pets
{
    public class PetsRepository : IPetsRepository
    {
        private readonly BaseContext _baseContext;
        public PetsRepository(BaseContext baseContext)
        {
            _baseContext = baseContext;
        }

        /*===================== CREAR NUEVO MASCOTA ======================*/
        public async Task<string> add(PetDto pet)
        {
            var NewPet = new Pet
            {
                Name = pet.Name,
                Race = pet.Race,
                Photo = pet.Photo,
                OwnerId = pet.OwnerId,
                
                DateBirth = pet.DateBirth,
                Specie = pet.Specie
            };
            _baseContext.Pets.Add(NewPet);
            _baseContext.SaveChanges();
            return "mascota Creada";

            
        }
        /*===================== lISTAR ======================*/
        public IEnumerable<Pet> GetAllPets()
        {
            return _baseContext.Pets.Include(a=>a.Owner).ToList();
        }


        public Pet GetById(int id)
        {
            var PetExists = _baseContext.Pets.Find(id);
            if (PetExists == null)
            {
                throw new Exception("Mascota no encontrada");
            }
            return  _baseContext.Pets.Include(a=>a.Owner).FirstOrDefault(a => a.Id == id);
        }
        /*===================== ACTUALIZAR ======================*/
        public Task<string> UptadePet(int id, PetDto petDto)
        {
            var pet = _baseContext.Pets.Find(id);

            pet.Name = petDto.Name;
            pet.Race = petDto.Race;
            pet.Photo = petDto.Photo; 
            pet.Specie = petDto.Specie;
            

            _baseContext.Pets.Update(pet);
            _baseContext.SaveChanges();
            return Task.FromResult("Mascota Actualizada");
        }
        /*===================== LISTAR MASCOTA POR FECHA DE CUMPLEAÑOS ======================*/
        
        public IEnumerable<Pet> GetByBirth(DateTime date)
        {
            return _baseContext.Pets.Include(a=>a.Owner).Where(d=>d.DateBirth == date).ToList();
        }
        /*===================== LISTAR MASCOTA POR DUEÑO ======================*/

        public IEnumerable<Pet> GetByOwner(string owner)
        {
            return _baseContext.Pets.Include(a=>a.Owner).Where(d=>d.Owner.Names == owner).ToList();
        }
    }
}