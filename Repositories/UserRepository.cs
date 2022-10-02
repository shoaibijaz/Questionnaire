using HealthQues.Core;
using HealthQues.Domain;
using HealthQues.DTOs;
using HealthQues.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace HealthQues.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserManager<AppUser> _userManager;

        public UserRepository(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<UserFormResponse> AddUpdate(UserDto user)
        {
            if (!string.IsNullOrEmpty(user.ID))
            {
                return await update(user);
            }
            else
            {
                return await addNew(user);
            }
        }

        public async Task<UserFormResponse> DeleteUser(UserDto user)
        {
            var userObject = await _userManager.FindByIdAsync(user.ID);
            var result = await _userManager.DeleteAsync(userObject);

            return new UserFormResponse() { IdentityResult = result, UserDto = user };
        }

        public async Task<UserDto> GetUser(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);

            var roles = await _userManager.GetRolesAsync(user);

            return new UserDto()
            {
                ID = Id,
                Name = user.UserName,
                Email = user.Email,
                DisplayName = user.DisplayName,
                Role = string.Join(",", roles)
            };
        }

        public async Task<List<UserDto>> GetUsersList()
        {
            var users = _userManager.Users.OrderByDescending(a=>a.CreatedOn).ToList();
            var results = new List<UserDto>();

            foreach (var item in users)
            {
                var roles = await _userManager.GetRolesAsync(item);

                results.Add(new UserDto
                {
                    Name = item.UserName,
                    DisplayName = item.DisplayName,
                    Email = item.Email,
                    ID = item.Id,
                    Role = string.Join(",", roles)
                }); ;

            }

            return results;
        }

        public async Task<UserFormResponse> ResetPassword(PasswordResetDto passwordResetDto)
        {
            var user = await _userManager.FindByIdAsync(passwordResetDto.ID);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, passwordResetDto.Password);

            return new UserFormResponse() { IdentityResult = result };
        }

        private async Task<UserFormResponse> addNew(UserDto user)
        {
            var appUser = new AppUser()
            {
                UserName = user.Name,
                DisplayName = user.DisplayName,
                Email = user.Email
            };

            var result = await _userManager.CreateAsync(appUser, user.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(appUser, user.Role);
                user.ID = appUser.Id;
            }

            return new UserFormResponse() { UserDto = user, IdentityResult = result };
        }

        private async Task<UserFormResponse> update(UserDto user)
        {
            var appUser = await _userManager.FindByIdAsync(user.ID);
            appUser.UserName = user.Name;
            appUser.DisplayName = user.DisplayName;
            appUser.Email = user.Email;
            var result = await _userManager.UpdateAsync(appUser);

            if (result.Succeeded)
            {
                var isInRole = await _userManager.IsInRoleAsync(appUser, user.Role);
                if (!isInRole)
                {
                    // Remove other roles
                    var roles = await _userManager.GetRolesAsync(appUser);
                    await _userManager.RemoveFromRolesAsync(appUser, roles);
                    await _userManager.AddToRoleAsync(appUser, user.Role);
                }

            }

            return new UserFormResponse() { UserDto = user, IdentityResult = result };
        }
    }
}
