namespace TestGuruApi.Entities.Dto.Responses
{
    public class CategoryResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid TestId { get; set; }

        public ICollection<QuestionResponse> Questions { get; set; }
    }
}
