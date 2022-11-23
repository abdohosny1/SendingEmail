using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SendingEmail.services.sendingEmail
{
    public interface IMailSendService
    {
        Task SendingEmail(string mailTo, string subject, string body,IList<IFormFile> ATTACHMENT =null);
    }
}
