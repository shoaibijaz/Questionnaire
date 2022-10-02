using HealthQues.Areas.Identity;
using HealthQues.Data;
using HealthQues.Domain;
using HealthQues.Repositories;
using HealthQues.Repositories.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;

namespace HealthQues.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static WebApplicationBuilder AddApplicationServices(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
               // options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<AppUser>>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IPatientRepository, PatientRepository>();
            builder.Services.AddScoped<IQuestionnaireRepository, QuestionnaireRepository>();
            builder.Services.AddScoped<IPatientQuestionnaireRespository, PatientQuestionnaireRespository>();
            builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
            builder.Services.AddScoped<IPatientAnswerRepository, PatientAnswerRepository>();

            return builder;
        }
    }
}
