using System.ComponentModel.DataAnnotations;

namespace TestGuru.Domain.Entities
{
    public class Group : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string GroupName { get; set; }

        public virtual ICollection<User> Members { get; set; }
    }
}
