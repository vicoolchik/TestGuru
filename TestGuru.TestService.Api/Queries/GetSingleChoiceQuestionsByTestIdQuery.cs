using MediatR;
using TestGuru.TestService.Contracts.Responses;

namespace TestGuru.TestService.Api.Queries
{
    public class GetSingleChoiceQuestionsByTestIdQuery : IRequest<IEnumerable<SingleChoiceQuestionResponse>>
    {
        public Guid TestId { get; set; }

        public GetSingleChoiceQuestionsByTestIdQuery(Guid testId)
        {
            TestId = testId;
        }
    }
}
