using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthQues.Domain
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public int QuestionnaireId { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public string Domain { get; set; }
        public string SelectionType { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedOn { get; set; }

        [ForeignKey("QuestionnaireId")]
        public Questionnaire Questionnaire { get; set; }

        [ForeignKey("ParentId")]
        public Question Parent { get; set; }

        public ICollection<QuestionAnswer> Answers { get; set; }
    }
}
