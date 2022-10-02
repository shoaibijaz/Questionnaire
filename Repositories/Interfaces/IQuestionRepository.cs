using HealthQues.Domain;

namespace HealthQues.Repositories.Interfaces
{
    public interface IQuestionRepository
    {
        public IEnumerable<Question> GetQuestions(int? QuestionnaireId);
    }
}
