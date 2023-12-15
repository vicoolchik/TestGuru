using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestGuru.Domain.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public string Description { get; set; }

        // Foreign key
        [Required]
        public Guid TestId { get; set; }

        // Navigation property
        [ForeignKey("TestId")]
        public virtual Test Test { get; set; }
        public virtual ICollection<Question> Questions { get; set; } = new HashSet<Question>();
    }
}
