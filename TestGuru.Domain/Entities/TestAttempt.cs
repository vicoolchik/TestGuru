using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestGuru.Domain.Entities
{
    public class TestAttempt : BaseEntity
    {
        [Required]
        public Guid TestTakerId { get; set; }

        [Required]
        public Guid TestId { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        public bool IsSuccessful { get; set; }

        [Required]
        public float Score { get; set; }

        public virtual ICollection<Answer> Responses { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public int CorrectAnswersCount { get; set; }

        [Required]
        public int IncorrectAnswersCount { get; set; }

        [Required]
        public int SkippedAnswersCount { get; set; }

        [Required]
        public int AttemptNumber { get; set; }

        // Navigation properties
        [ForeignKey("TestTakerId")]
        public virtual TestTaker TestTaker { get; set; }

        [ForeignKey("TestId")]
        public virtual Test Test { get; set; }
    }
}
