using HealthQues.Data;
using HealthQues.Domain;
using Microsoft.AspNetCore.Identity;

namespace HealthQues.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static WebApplicationBuilder AddIdentityServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddDefaultIdentity<AppUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            }).AddRoles<IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            return builder;
        }

    }
}
