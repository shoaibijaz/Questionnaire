using System.ComponentModel.DataAnnotations;

namespace HealthQues.DTOs
{
    public class PasswordResetDto
    {
        public string ID { get; set; }

        [Required(ErrorMessage = "Password is mandatory")]
        public string Password { get; set; }
    }
}
