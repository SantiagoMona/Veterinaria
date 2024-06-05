using riwivet.Data;
using riwivet.Dto;
using riwivet.Models;
using Microsoft.EntityFrameworkCore;

namespace riwivet.Services.Owners
{
    public class OwnersRepository : IOwnersRepository
    {
        private readonly BaseContext _baseContext;
        public OwnersRepository(BaseContext baseContext)
        {
            _baseContext = baseContext;
        }

        /*===================== CREAR ======================*/
        public async Task<string> add(OwnerDto ownerDto)
        {
            var SerchEmailExists = await _baseContext.Owners.FirstOrDefaultAsync(E => E.Email == ownerDto.Email);
            if (SerchEmailExists!= null)
            {
                return "Ya existe un dueño con ese correo";
            }
            var NewOwner = new Owner
            {
                Names = ownerDto.Names,
                LastNames = ownerDto.LastNames,
                Email = ownerDto.Email,
                Phone = ownerDto.Phone,
                Address = ownerDto.Address,
                
            };
            _baseContext.Owners.Add(NewOwner);
            _baseContext.SaveChanges();
            return NewOwner.Names + " " + NewOwner.LastNames + "Creado exitosamente";
        }

        /*===================== lISTAR ======================*/

        public IEnumerable<Owner> GetAllOwners()
        {
            return _baseContext.Owners.ToList();
        }

        public Owner GetById(int id)
        {
            var OwnerExists = _baseContext.Owners.Find(id);
            if (OwnerExists!= null)
            {
                throw new Exception("Dueño no encontrado");
            }

            return _baseContext.Owners.Find(id);
        }

        /*===================== ACTUALIZAR ======================*/

        public async Task<string> UptadeOwner(int id, OwnerDto ownerDto)
        {
            var SerchOwner = _baseContext.Owners.Find(id);
            if (SerchOwner!= null)
            {
                SerchOwner.Names = ownerDto.Names;
                SerchOwner.LastNames = ownerDto.LastNames;
                SerchOwner.Email = ownerDto.Email;
                SerchOwner.Phone = ownerDto.Phone;
                SerchOwner.Address = ownerDto.Address;

                _baseContext.Update(SerchOwner);
                _baseContext.SaveChanges();

                return "Dueño actualizado exitosamente"+SerchOwner.Names;
            }
            return "Dueño no encontrado";
        }
    }


}