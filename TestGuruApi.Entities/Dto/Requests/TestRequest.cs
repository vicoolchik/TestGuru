using System.ComponentModel.DataAnnotations;

namespace TestGuruApi.Entities.Dto.Requests
{
    public class TestRequest
    {
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        public string Description { get; set; }

        public float MinimumPassingScore { get; set; }

        public DateTime? ScheduledPublishTime { get; set; }

        public DateTime? ScheduledClosingTime { get; set; }

        public DateTime? Duration { get; set; }

        public int TotalQuestionsCount { get; set; }

        public Guid? TestCollectionId { get; set; }
    }
}
