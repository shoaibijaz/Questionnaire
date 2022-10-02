using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthQues.Domain
{
    public class Questionnaire
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string CreatedById { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [ForeignKey("CreatedById")]
        public AppUser CreatedBy { get; set; }
    }
}
