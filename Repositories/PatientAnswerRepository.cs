using HealthQues.Data;
using HealthQues.Domain;
using HealthQues.Repositories.Interfaces;

namespace HealthQues.Repositories
{
    public class PatientAnswerRepository: IPatientAnswerRepository
    {

        private ApplicationDbContext dbContext;
        public PatientAnswerRepository(ApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }
        public async Task<int> Add(PatientAnswer patientAnswer)
        {
            dbContext.PatientAnswers.Add(patientAnswer);

            return await dbContext.SaveChangesAsync();
        }
    }
}
