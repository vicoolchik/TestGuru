namespace TestGuruApi.Entities.Dto.Responses
{
    public class MatchingQuestionResponse : QuestionResponse
    {
        public IDictionary<string, string> Matches { get; set; }
    }
}
