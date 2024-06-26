using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace riwivet.Services.Mailsend
{
    public interface IEmailSendRepository
    {
        Task<string> SendEmailAsync(string info,string toemail);
    }
}