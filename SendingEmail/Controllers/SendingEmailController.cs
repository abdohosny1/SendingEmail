using MailKit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SendingEmail.DTO;
using SendingEmail.services.sendingEmail;
using System.Threading.Tasks;

namespace SendingEmail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendingEmailController : ControllerBase
    {

        private readonly IMailSendService _mailService;

        public SendingEmailController(IMailSendService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost("send")]

        public async Task<IActionResult> sendEmail([FromForm] MailRequestDTO mailRequestDTO)
        {
            await _mailService.SendingEmail(mailRequestDTO.tOEmail, mailRequestDTO.Subject,mailRequestDTO.Body, mailRequestDTO.Attachment);
            return Ok();
        }

    }
}
