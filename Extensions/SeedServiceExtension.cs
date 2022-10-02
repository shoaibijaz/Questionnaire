using HealthQues.Data;
using HealthQues.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HealthQues.Extensions
{
    public static class SeedServiceExtension
    {
        public static WebApplication AddDataSeedService(this WebApplication app)
        {
            var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;

            try
            {
                var context = services.GetRequiredService<ApplicationDbContext>();
                var userManager = services.GetRequiredService<UserManager<AppUser>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                context.Database.Migrate();
                Seed.SeedData(context, userManager, roleManager);
                //QuestionSeeds.SeedData(context);
            }
            catch (Exception)
            {
                // Exception handling
            }

            return app;
        }
    }
}
