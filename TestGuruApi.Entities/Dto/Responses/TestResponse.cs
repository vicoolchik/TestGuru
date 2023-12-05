namespace TestGuruApi.Entities.Dto.Responses
{
    public class TestResponse
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public float MinimumPassingScore { get; set; }

        public DateTime? ScheduledPublishTime { get; set; }

        public DateTime? ScheduledClosingTime { get; set; }

        public DateTime? Duration { get; set; }

        public int TotalQuestionsCount { get; set; }
    }
}
