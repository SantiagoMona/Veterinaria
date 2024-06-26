using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using riwivet.Models;
using riwivet.Services.Mailsend;

namespace riwivet.Controllers.EmailSend
{
    [Route("[controller]")]
    public class EmailSendController : Controller
    {
        private readonly IEmailSendRepository emailSendRepository;
        public EmailSendController(IEmailSendRepository emailSendRepository)
        {
            this.emailSendRepository = emailSendRepository;
        }
       [HttpPost]
       [Route("api/emailsend")]
       public async Task<IActionResult> Post([FromBody] MailSendOptions mailSend)
       {
        try
        {
            await emailSendRepository.SendEmailAsync(mailSend.asunto,mailSend.toemail);
            return Ok();
        }
        catch (Exception ex)
        {
            
            return StatusCode(StatusCodes.Status500InternalServerError,"Error en el envio del correo" + ex.Message);
        }
       }
      
    }
}