using MediatR;
using TestGuruApi.Entities.Dto.Responses;

namespace TestGuruApi.TestService.Queries
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
