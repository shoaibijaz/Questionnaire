using HealthQues.Domain;

namespace HealthQues.Repositories.Interfaces
{
    public interface IPatientRepository
    {
        public Task<int> AddUpdate(Patient patient);
        public IEnumerable<Patient> GetList(string PhysicianId);
        public Task<int> Delete(Patient patient);
    }
}
