namespace TestGuru.TestService.Contracts.Responses
{
    public class MultipleChoiceQuestionResponse : QuestionResponse
    {
        public ICollection<AnswerResponse> PossibleAnswers { get; set; }
    }
}
