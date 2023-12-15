using System.ComponentModel.DataAnnotations;

namespace TestGuru.TestService.Contracts.Requests
{
    public class TestCollectionRequest
    {
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
