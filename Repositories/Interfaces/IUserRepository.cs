using HealthQues.Core;
using HealthQues.Domain;
using HealthQues.DTOs;

namespace HealthQues.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<UserDto> GetUser(string Id);
        public Task<List<UserDto>> GetUsersList();
        public Task<UserFormResponse> AddUpdate(UserDto user);
        public Task<UserFormResponse> DeleteUser(UserDto user);
        public Task<UserFormResponse> ResetPassword(PasswordResetDto passwordResetDto);
    }
}
