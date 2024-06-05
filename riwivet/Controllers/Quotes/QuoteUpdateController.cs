using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using riwivet.Dto;
using riwivet.Services.Quotes;

namespace riwivet.Controllers.Quotes
{
    public class QuoteUpdateController : ControllerBase
    {
       private readonly IQuoteRepository _Quote;
        public QuoteUpdateController(IQuoteRepository Quote)
        {
         _Quote = Quote;
        }

        [HttpPut]
        [Route("/Quotes/{id}")]
        public async Task<IActionResult> UpdateQuot(int id, [FromBody] QuoteDto quote)
        {
            await _Quote.UptadeQuote(id,quote);
            return NoContent();
        }
    }
}