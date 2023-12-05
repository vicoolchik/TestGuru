using System.ComponentModel.DataAnnotations;

namespace TestGuruApi.Entities.Dto.Requests
{
    public class CategoryRequest
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public Guid TestId { get; set; }
    }
}
