using System.ComponentModel.DataAnnotations.Schema;

namespace TestGuru.Domain.Entities
{
    public class AccessControlEntry : BaseEntity
    {
        [ForeignKey(nameof(Test))]
        public Guid TestId { get; set; }
        public virtual Test Test { get; set; }

        public virtual ICollection<User> UsersWithAccess { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
