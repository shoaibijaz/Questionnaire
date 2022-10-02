using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthQues.Domain
{
    public enum QuestionnaireStatus
    {
        Pending,
        Recommendation,
        Completed
    }

    public class PatientQuestionnaire
    {
        [Key]
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int QuestionnaireId { get; set; }
        public QuestionnaireStatus Status { get; set; }
        public double Score { get; set; }
        public string Recommendations { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [ForeignKey("QuestionnaireId")]
        public Questionnaire Questionnaire { get; set; }

        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
    }
}
