using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestGuru.Domain.Entities
{
    public class TestCollection : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
        public string Description { get; set; }

        // Foreign key
        [Required]
        public Guid CreatorId { get; set; }

        // Navigation properties
        [ForeignKey(nameof(CreatorId))]
        public virtual Creator Creator { get; set; }
        public virtual ICollection<Test> Tests { get; set; } = new HashSet<Test>();
    }
}
