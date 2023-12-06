using MediatR;
using TestGuruApi.Entities.Dto.Responses;

namespace TestGuruApi.TestService.Queries
{
    public class GetAnswersByQuestionQuery : IRequest<IEnumerable<AnswerResponse>>
    {
        public Guid QuestionId { get; set; }

        public GetAnswersByQuestionQuery(Guid questionId)
        {
            QuestionId = questionId;
        }
    }
}
