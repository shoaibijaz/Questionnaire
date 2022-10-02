using HealthQues.Data;
using HealthQues.Domain;
using HealthQues.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthQues.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private ApplicationDbContext dbContext;
        public PatientRepository(ApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }
        public async Task<int> AddUpdate(Patient patient)
        {
            if (patient.Id > 0)
            {
                var patientItem = await dbContext.Patients.FindAsync(patient.Id);
                patientItem.PatientId = patient.PatientId;
                patientItem.PhysicianId = patient.PhysicianId;
                dbContext.Patients.Update(patientItem);
            }
            else
            {
                dbContext.Patients.Add(patient);
            }

            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(Patient patient)
        {
            dbContext.Patients.Remove(patient);

            return await dbContext.SaveChangesAsync();
        }

        public IEnumerable<Patient> GetList(string PhysicianId = null)
        {
            var data = dbContext.Patients.Include(a=>a.PhysicianUser).Include(a=>a.PatientUser).Where(a=>a.Id>0);

            if(!string.IsNullOrEmpty(PhysicianId))
            {
                data = data.Where(a => a.PhysicianId == PhysicianId);
            }

            return data;
        }
    }
}
