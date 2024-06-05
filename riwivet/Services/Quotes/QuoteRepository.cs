
using riwivet.Models;
using riwivet.Data;
using riwivet.Dto;
using Microsoft.EntityFrameworkCore;

namespace riwivet.Services.Quotes
{
    public class QuoteRepository : IQuoteRepository
    {
        private readonly BaseContext _baseContext;
        public QuoteRepository(BaseContext baseContext)
        {
            _baseContext = baseContext;
        }
        /*===================== ACTUALIZAR ======================*/
        public async Task<string> add(QuoteDto quote)
        {
            var NewQuore = new Quote
            {
                Data = quote.Data,
                Description = quote.Description,
                PetId = quote.PetId,
                VetId = quote.VetId  
            };
            _baseContext.Quotes.Add(NewQuore);
            _baseContext.SaveChanges();
            return "Cita Creada exitosamente";
        }

        /*===================== LISTAR ======================*/
        public IEnumerable<Quote> GetAllQuotes()
        {
            return _baseContext.Quotes.Include(a => a.Pet).Include(a => a.Vet).Include(a => a.Pet.Owner).ToList();
        }

        public Quote GetQuoteById(int id)
        {
            return _baseContext.Quotes.Include(a => a.Pet).Include(a => a.Vet).FirstOrDefault(a => a.Id == id);
        }
        /*===================== ACTUALIZAR ======================*/
        public async Task<string> UptadeQuote(int id, QuoteDto quoteDto)
        {
            var Serch = _baseContext.Quotes.Find(id);
            if (Serch!= null)
            {
                Serch.Data = quoteDto.Data;
                Serch.Description = quoteDto.Description;
                Serch.PetId = quoteDto.PetId;
                Serch.VetId = quoteDto.VetId;
                

                _baseContext.Update(Serch);
                _baseContext.SaveChanges();

                return "Cita actualizada exitosamente"+ quoteDto.Description;
            }
            return "Cita no encontrada";
        }
         /*===================== lISTAR CITAS POR VETERINARIO ======================*/
        public IEnumerable<Quote> CitasVeterinario(int id)
        {
            return _baseContext.Quotes.Include(a => a.Pet).Include(a => a.Vet).Include(a => a.Pet.Owner).Where(a => a.Vet.Id == id).ToList();
        }
        
        /*===================== lISTAR CITAS POR FECHA ======================*/
        public IEnumerable<Quote> GetByDate(DateTime date)
        {
            return _baseContext.Quotes.Include(a => a.Pet).Include(a => a.Vet).Include(a => a.Pet.Owner).Where(a => a.Data == date).ToList();
        }

        
    }
}