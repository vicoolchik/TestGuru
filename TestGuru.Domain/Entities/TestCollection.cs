using System.ComponentModel.DataAnnotations;

namespace TestGuru.Domain.Entities
{
    public class TestCollection : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
        public string Description { get; set; }

        // Foreign key
        //[Required]
        //public Guid CreatorId { get; set; }

        // Navigation properties
        //[ForeignKey("CreatorId")]
        //public virtual User Creator { get; set; }
        public virtual ICollection<Test> Tests { get; set; } = new HashSet<Test>();
    }
}
