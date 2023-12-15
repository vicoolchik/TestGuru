using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestGuru.Domain.Entities
{
    public class Answer : BaseEntity
    {
        [Required]
        public string Content { get; set; }
        [Required]
        public bool IsCorrect { get; set; }
        public string Explanation { get; set; }

        // Foreign key
        [Required]
        public Guid QuestionId { get; set; }

        // Navigation properties
        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }
    }
}
