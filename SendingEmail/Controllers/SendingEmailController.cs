using MailKit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SendingEmail.DTO;
using SendingEmail.services.sendingEmail;
using System.IO;
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
        [HttpPost("welcome")]
        public async Task<IActionResult> SendWelcomeEmail([FromBody] WelcomeRequestDto dto)
        {
            var filePath = $"{Directory.GetCurrentDirectory()}\\Templates\\EmailTemplate.html";
            var str = new StreamReader(filePath);

            var mailText = str.ReadToEnd();
            str.Close();

            mailText = mailText.Replace("[username]", dto.UserName).Replace("[email]", dto.Email);

            await _mailService.SendingEmail(dto.Email, "Welcome to our channel", mailText);
            return Ok();
        }

    }
}
