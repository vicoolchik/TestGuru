namespace TestGuru.TestService.Contracts.Requests
{
    public class MultipleChoiceQuestionRequest : QuestionRequest
    {
        public List<Guid> CorrectAnswerIds { get; set; }
    }
}
