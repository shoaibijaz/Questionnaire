using HealthQues.Data;
using HealthQues.Domain;
using HealthQues.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthQues.Repositories
{
    public class PatientQuestionnaireRespository: IPatientQuestionnaireRespository
    {
        private ApplicationDbContext dbContext;
        public PatientQuestionnaireRespository(ApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }
        public async Task<int> Add(PatientQuestionnaire patientQuestionnaire)
        {
            dbContext.PatientQuestionnaires.Add(patientQuestionnaire);

            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(PatientQuestionnaire patientQuestionnaire)
        {
            dbContext.PatientQuestionnaires.Remove(patientQuestionnaire);

            return await dbContext.SaveChangesAsync();
        }

        public IEnumerable<PatientQuestionnaire> GetList()
        {
            var data = dbContext.PatientQuestionnaires.Include(a => a.Patient).Include(a => a.Questionnaire).Where(a => a.Id > 0);

            return data;
        }
    }
}
