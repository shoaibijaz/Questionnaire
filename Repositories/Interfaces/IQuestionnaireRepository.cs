using HealthQues.Domain;

namespace HealthQues.Repositories.Interfaces
{
    public interface IQuestionnaireRepository
    {
        public Task<int> AddUpdate(Questionnaire questionnaire);
        public IEnumerable<Questionnaire> GetList();
        public Task<int> SoftDelete(Questionnaire questionnaire);
    }
}
