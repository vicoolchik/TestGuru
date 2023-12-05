namespace TestGuruApi.Entities.Dto.Responses
{
    public class QuestionResponse
    {
        public Guid Id { get; set; }

        public string Content { get; set; }

        public float Points { get; set; }

        public Guid CategoryId { get; set; }

        public Guid TestId { get; set; }

        public ICollection<AnswerResponse> Answers { get; set; }
    }
}
