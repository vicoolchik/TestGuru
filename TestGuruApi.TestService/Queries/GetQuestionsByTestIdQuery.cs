using MediatR;
using TestGuruApi.Entities.Dto.Responses;

namespace TestGuruApi.TestService.Queries
{
    public class GetQuestionsByTestIdQuery : IRequest<IEnumerable<QuestionResponse>>
    {
        public Guid TestId { get; set; }

        public GetQuestionsByTestIdQuery(Guid testId)
        {
            TestId = testId;
        }
    }
}
