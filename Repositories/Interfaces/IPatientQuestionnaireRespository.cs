using HealthQues.Domain;

namespace HealthQues.Repositories.Interfaces
{
    public interface IPatientQuestionnaireRespository
    {
        public Task<int> Add(PatientQuestionnaire patientQuestionnaire);
        public IEnumerable<PatientQuestionnaire> GetList();
        public Task<int> Delete(PatientQuestionnaire patientQuestionnaire);
    }
}
