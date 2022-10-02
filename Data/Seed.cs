using HealthQues.Domain;
using Microsoft.AspNetCore.Identity;
using System.Text;

namespace HealthQues.Data
{
    public class Seed
    {
        public static void SeedData(ApplicationDbContext context,
            UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var userWithRoles = new List<KeyValuePair<string, AppUser>>()
            {
                new KeyValuePair<string, AppUser>("Admin", new AppUser {
                        DisplayName = "Admin",
                        UserName = "admin",
                        Email = "admin@domain.com"

                    }),
                new KeyValuePair<string, AppUser>("Patient", new AppUser {
                        DisplayName = "Patient",
                        UserName = "patient",
                        Email = "patient@domain.com"
                    }),
                new KeyValuePair<string, AppUser>("Caregiver", new AppUser {
                        DisplayName = "Caregiver",
                        UserName = "caregiver",
                        Email = "caregiver@domain.com"
                    }),
                new KeyValuePair<string, AppUser>("Coordinator", new AppUser {
                        DisplayName = "Coordinator",
                        UserName = "coordinator",
                        Email = "coordinator@domain.com"
                    }),
                new KeyValuePair<string, AppUser>("Physician", new AppUser {
                        DisplayName = "Physician",
                        UserName = "physician",
                        Email = "physician@domain.com"
                    }),
                new KeyValuePair<string, AppUser>("Adviser", new AppUser {
                        DisplayName = "Adviser",
                        UserName = "adviser",
                        Email = "adviser@domain.com"
                    })
            };

            if (!roleManager.Roles.Any())
            {
                userWithRoles.ForEach(role =>
                {
                    roleManager.CreateAsync(new IdentityRole(role.Key)).Wait();
                });
            }

            if (!userManager.Users.Any())
            {
                foreach (var item in userWithRoles)
                {
                    var user = item.Value;
                    userManager.CreateAsync(user, "password").Wait();
                    userManager.AddToRoleAsync(user, item.Key).Wait();
                }

                context.SaveChanges();
            }
        }

    }
}
