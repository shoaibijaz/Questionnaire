namespace HealthQues.DTOs
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public int QuestionnaireId { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public string Domain { get; set; }
        public string SelectionType { get; set; }
        public QuestionDto? Parent { get; set; }
        public List<AnswerDto> Answers { get; set; } = new List<AnswerDto>();
    }
}
