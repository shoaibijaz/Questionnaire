using System.ComponentModel.DataAnnotations;

namespace HealthQues.DTOs
{
    public class UserDto
    {
        public string ID { get; set; }

        [Required(ErrorMessage = "Login name is mandatory")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Display name is mandatory")]
        public string DisplayName { get; set; }

        [Required(ErrorMessage = "Email is mandatory")]
        public string Email { get; set; }
        public string Role { get; set; }

        [Required(ErrorMessage = "Password is mandatory")]
        public string Password { get; set; }
    }
}
