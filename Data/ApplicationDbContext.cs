using HealthQues.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthQues.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Question>().HasMany(a => a.Answers).WithOne(a=>a.Question);
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Questionnaire> Questionnaires { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswers { get; set; }
        public DbSet<PatientQuestionnaire> PatientQuestionnaires { get; set; }
        public DbSet<PatientAnswer> PatientAnswers { get; set; }
    }
}