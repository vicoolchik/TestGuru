using System.ComponentModel.DataAnnotations;

namespace TestGuru.TestService.Contracts.Requests
{
    public class QuestionRequest
    {
        [Required]
        public string Content { get; set; }

        [Required]
        public float Points { get; set; }

        public Guid? CategoryId { get; set; }

        [Required]
        public Guid TestId { get; set; }
    }
}
