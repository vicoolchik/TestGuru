namespace TestGuru.TestService.Contracts.Responses
{
    public class MatchingQuestionResponse : QuestionResponse
    {
        public IDictionary<string, string> Matches { get; set; }
    }
}
