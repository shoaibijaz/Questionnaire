using HealthQues.Domain;

namespace HealthQues.Repositories.Interfaces
{
    public interface IPatientAnswerRepository
    {
        public Task<int> Add(PatientAnswer patientAnswer);
    }
}
