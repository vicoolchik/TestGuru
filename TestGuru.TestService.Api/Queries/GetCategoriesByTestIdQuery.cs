using MediatR;
using TestGuru.TestService.Contracts.Responses;

namespace TestGuru.TestService.Api.Queries
{
    public class GetCategoriesByTestIdQuery : IRequest<IEnumerable<CategoryResponse>>
    {
        public Guid TestId { get; private set; }

        public GetCategoriesByTestIdQuery(Guid testId)
        {
            TestId = testId;
        }
    }
}
