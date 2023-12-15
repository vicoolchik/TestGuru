using MediatR;
using TestGuru.TestService.Contracts.Responses;

namespace TestGuru.TestService.Api.Queries
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
