namespace TestGuruApi.Entities.Dto.Responses
{
    public class AnswerResponse
    {
        public Guid Id { get; set; }

        public string Content { get; set; }

        public bool IsCorrect { get; set; }

        public string Explanation { get; set; }

        public Guid QuestionId { get; set; }
    }
}
