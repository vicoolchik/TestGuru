namespace TestGuru.TestService.Contracts.Requests
{
    public class MatchingQuestionRequest : QuestionRequest
    {
        public Dictionary<string, string> Pairs { get; set; }
    }
}
