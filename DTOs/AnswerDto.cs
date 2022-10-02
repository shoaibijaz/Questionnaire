namespace HealthQues.DTOs
{
    public class AnswerDto
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int? SubQuestionId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public double ScorePoint { get; set; }
    }
}
