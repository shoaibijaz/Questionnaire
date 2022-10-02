using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthQues.Domain
{
    public class QuestionAnswer
    {
        [Key]
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int? SubQuestionId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public double ScorePoint { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedOn { get; set; }

        [ForeignKey("QuestionId")]
        public Question Question { get; set; }

        [ForeignKey("SubQuestionId")]
        public Question SubQuestion { get; set; }
    }
}
