using System.ComponentModel.DataAnnotations;

namespace SendingEmail.DTO
{
    public class WelcomeRequestDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
