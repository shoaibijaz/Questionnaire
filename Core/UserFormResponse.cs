using HealthQues.DTOs;
using Microsoft.AspNetCore.Identity;

namespace HealthQues.Core
{
    public class UserFormResponse
    {
        public UserDto UserDto { get; set; } = new();
        public IdentityResult IdentityResult { get; set; } = new();
    }
}
