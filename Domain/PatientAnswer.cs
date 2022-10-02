using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthQues.Domain
{
    public class PatientAnswer
    {
        [Key]
        public int Id { get; set; }
        public int PatientQuestionnaireId { get; set; }
        public int AnswerId { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [ForeignKey("PatientQuestionnaireId")]
        public PatientQuestionnaire PatientQuestionnaire { get; set; }

        [ForeignKey("AnswerId")]
        public QuestionAnswer Answer { get; set; }

    }
}
