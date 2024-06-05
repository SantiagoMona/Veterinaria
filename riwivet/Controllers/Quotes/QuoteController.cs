using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using riwivet .Services.Quotes;
using riwivet.Models;

namespace riwivet.Controllers.Quotes
{

  public class QuoteController : ControllerBase
  {
    private readonly IQuoteRepository _Quote;
    public QuoteController(IQuoteRepository Quote)
    {
      _Quote = Quote;
    }
    [HttpGet]
    [Route("/Quotes")]
    public IEnumerable<Quote> ListAll()
    {
      return _Quote.GetAllQuotes();
    }
    [HttpGet]
    [Route("/Quotes/{id}")]
    public Quote Get(int id)
    {
      return _Quote.GetQuoteById(id);
    }
    [HttpGet]
    [Route("/Quotes/{date}/Date")]
    public IEnumerable<Quote> GetByDate(DateTime date)
    {
      return _Quote.GetByDate(date);
    }
    [HttpGet]
    [Route("/Quotes/{id}/Vets")]
    public IEnumerable<Quote> GetByCita(int id)
    {
      return _Quote.CitasVeterinario(id);
    }
  }
}