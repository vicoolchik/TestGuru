using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestGuru.Domain.Entities
{
    public class Test : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
        public string Description { get; set; }
        public float MinimumPassingScore { get; set; }
        //public int MaxAttemptsPerUser { get; set; }
        public DateTime? ScheduledPublishTime { get; set; }

        public DateTime? ScheduledClosingTime { get; set; }

        public TimeSpan? Duration { get; set; }

        public int TotalQuestionsCount { get; set; }
        public bool? IsPublic { get; set; }

        // Foreign key
        [Required]
        public Guid CreatorId { get; set; }
        public Guid? TestCollectionId { get; set; }

        // Navigation properties
        public virtual ICollection<Question> Questions { get; set; } = new HashSet<Question>();
        public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>();
        public virtual ICollection<AnswerVisibilityPolicy> AnswerVisibilityPolicies { get; set; } = new HashSet<AnswerVisibilityPolicy>();
        public virtual ICollection<AccessControlEntry> AccessControlEntries { get; set; } = new HashSet<AccessControlEntry>();
        public virtual ICollection<TestAttempt> TestAttempts { get; set; } = new HashSet<TestAttempt>();
        [ForeignKey(nameof(CreatorId))]
        public virtual Creator Creator { get; set; }
        [ForeignKey("TestCollectionId")]
        public virtual TestCollection TestCollection { get; set; }

    }
}
