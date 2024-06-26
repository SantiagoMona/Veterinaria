using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace riwivet.Services.Mailsend
{
    public class EmailSendRepository : IEmailSendRepository
    {
        private readonly string? ApiURL;
    
        private readonly string? ApiKEY;
        private readonly string? fromEmail;

        private readonly HttpClient _client;
        public EmailSender(HttpClient httpClient, IConfiguration configuration){
            _client = httpClient;
            ApiKEY = configuration["MailSend:ApiURL"];
        }
        public Task<string> SendEmailAsync(string info, string toemail)
        {
            var request = new{
                from = new {email = fromEmail},
                to = new {email = toemail},
                subjet = "este correo se envio desde laapi",
                text = "correo de prubea"
            };
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",ApiKEY);

            
        }
    }
}