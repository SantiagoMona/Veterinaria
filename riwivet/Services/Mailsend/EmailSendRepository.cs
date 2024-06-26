using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;

namespace riwivet.Services.Mailsend
{
    public class EmailSendRepository : IEmailSendRepository
    {
        private readonly string? ApiURL;
    
        private readonly string? ApiKEY;
        private readonly string? fromEmail;

        private readonly HttpClient _client;
        public EmailSendRepository(HttpClient httpClient, IConfiguration configuration){
            _client = httpClient;
            ApiKEY = configuration["MailSend:ApiURL"];
        }
        public async Task<string> SendEmailAsync(string info, string toemail)
        {
            var request = new{
                from = new {email = fromEmail},
                to = new {email = toemail},
                subjet = "este correo se envio desde laapi",
                text = "correo de prubea"
            };
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",ApiKEY);
             var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(ApiURL, content);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                // Manejo de errores, puede ser lanzar una excepción o devolver un mensaje de error
                var error = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error enviando correo: {error}");
            }
        }
    }
}