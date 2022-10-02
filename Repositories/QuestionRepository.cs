using HealthQues.Data;
using HealthQues.Domain;
using HealthQues.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthQues.Repositories
{
    public class QuestionRepository: IQuestionRepository
    {
        private ApplicationDbContext dbContext;
        public QuestionRepository(ApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }
        public IEnumerable<Question> GetQuestions(int? QuestionnaireId)
        {
            var data = dbContext.Questions.Include(a=>a.Answers).Where(a=>a.IsDeleted == false);

            if (QuestionnaireId !=null)
            {
                data = data.Where(a=>a.QuestionnaireId == QuestionnaireId);
            }

            return data;
        }
    }
}
