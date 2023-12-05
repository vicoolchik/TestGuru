using System.ComponentModel.DataAnnotations;

namespace TestGuruApi.Entities.Dto.Requests
{
    public class AnswerRequest
    {
        [Required]
        public string Content { get; set; }

        [Required]
        public bool IsCorrect { get; set; }

        public string Explanation { get; set; }

        [Required]
        public Guid QuestionId { get; set; }
    }
}
