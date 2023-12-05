namespace TestGuruApi.Entities.Dto.Responses
{
    public class MultipleChoiceQuestionResponse : QuestionResponse
    {
        public ICollection<AnswerResponse> PossibleAnswers { get; set; }
    }
}
