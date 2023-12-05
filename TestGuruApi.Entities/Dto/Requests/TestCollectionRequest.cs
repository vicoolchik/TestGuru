using System.ComponentModel.DataAnnotations;

namespace TestGuruApi.Entities.Dto.Requests
{
    public class TestCollectionRequest
    {
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
