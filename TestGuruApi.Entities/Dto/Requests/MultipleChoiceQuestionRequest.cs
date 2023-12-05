namespace TestGuruApi.Entities.Dto.Requests
{
    public class MultipleChoiceQuestionRequest : QuestionRequest
    {
        public List<Guid> CorrectAnswerIds { get; set; }
    }
}
