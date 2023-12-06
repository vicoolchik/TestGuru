using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestGuruApi.Entities.DbSet
{
    public abstract class Question : BaseEntity
    {
        [Required]
        public string Content { get; set; }
        [Required]
        public float Points { get; set; }

        // Foreign keys
        public Guid? CategoryId { get; set; }
        [Required]
        public Guid TestId { get; set; }

        // Navigation properties
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        [ForeignKey("TestId")]
        public virtual Test Test { get; set; }
        public virtual ICollection<Answer> Answers { get; set; } = new HashSet<Answer>();
        public abstract bool ValidateAnswer(Answer answer);
    }
}
