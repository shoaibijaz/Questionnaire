using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthQues.Domain
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Patient is mandatory")]
        public string PatientId { get; set; }

        [Required(ErrorMessage = "Physician is mandatory")]
        public string PhysicianId { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [ForeignKey("PatientId")]
        public AppUser PatientUser { get; set; }

        [ForeignKey("PhysicianId")]
        public AppUser PhysicianUser { get; set; }

        [ForeignKey("CreatedById")]
        public AppUser CreatedBy { get; set; }
    }
}
