using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TestGuru.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {

        [MaxLength(255)]
        public string? FirstName { get; set; }

        [MaxLength(255)]
        public string? LastName { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}
