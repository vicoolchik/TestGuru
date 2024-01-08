namespace TestGuru.Domain.Entities
{
    public class AnswerVisibilityPolicy : BaseEntity
    {
        public AnswerVisibilityTiming Timing { get; set; }
        public AnswerVisibilityLevel Level { get; set; }
    }
}
