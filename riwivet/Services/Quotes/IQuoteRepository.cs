using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using riwivet.Dto;
using riwivet.Data;
using riwivet.Models;

namespace riwivet.Services.Quotes
{
    public interface IQuoteRepository
    {
        IEnumerable<Quote> GetAllQuotes();
        Quote GetQuoteById(int id);
        Task<string> UptadeQuote(int id, QuoteDto quoteDto);
        Task<string> add(QuoteDto quoteDto);
        IEnumerable<Quote> GetByDate(DateTime date); 
        IEnumerable<Quote> CitasVeterinario(int id) ;
    }
}