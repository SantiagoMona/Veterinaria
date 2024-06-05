using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using riwivet.Dto;
using riwivet.Models;
using riwivet.Services.Quotes;

namespace riwivet.Controllers.Quotes
{
    
    public class QuoteCreateController : ControllerBase
    {
       private readonly IQuoteRepository _Quote;
        public QuoteCreateController(IQuoteRepository Quote)
        {
        _Quote = Quote;
        }
        [HttpPost]
        [Route("/Quote")]
        public async Task<ActionResult> Create([FromBody]QuoteDto quote )
        {
            var newQuote = await _Quote.add(quote);
            return Ok(newQuote);
        }
    }
}