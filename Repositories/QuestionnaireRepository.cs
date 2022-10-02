using HealthQues.Data;
using HealthQues.Domain;
using HealthQues.Repositories.Interfaces;

namespace HealthQues.Repositories
{
    public class QuestionnaireRepository: IQuestionnaireRepository
    {
        private ApplicationDbContext dbContext;
        public QuestionnaireRepository(ApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }
        public async Task<int> AddUpdate(Questionnaire questionnaire)
        {
            if (questionnaire.Id > 0)
            {
                var objectItem = await dbContext.Questionnaires.FindAsync(questionnaire.Id);
                objectItem.Title = questionnaire.Title;
                dbContext.Questionnaires.Update(objectItem);
            }
            else
            {
                dbContext.Questionnaires.Add(questionnaire);
            }

            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> SoftDelete(Questionnaire questionnaire)
        {
            var objectItem = await dbContext.Questionnaires.FindAsync(questionnaire.Id);
            if (objectItem == null) return 0;
            objectItem.IsDeleted = true;
            dbContext.Questionnaires.Update(objectItem);
            return await dbContext.SaveChangesAsync();
        }

        public IEnumerable<Questionnaire> GetList()
        {
            var data = dbContext.Questionnaires.Where(a => a.IsDeleted ==false);
            return data;
        }
    }
}
