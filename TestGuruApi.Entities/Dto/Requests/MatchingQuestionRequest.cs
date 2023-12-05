namespace TestGuruApi.Entities.Dto.Requests
{
    public class MatchingQuestionRequest: QuestionRequest
    {
        public Dictionary<string, string> Pairs { get; set; }
    }
}
