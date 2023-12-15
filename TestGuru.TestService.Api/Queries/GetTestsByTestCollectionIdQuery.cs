using MediatR;
using TestGuru.TestService.Contracts.Responses;

namespace TestGuru.TestService.Api.Queries
{
    public class GetTestsByTestCollectionIdQuery : IRequest<IEnumerable<TestResponse>>
    {
        public Guid TestCollectionId { get; private set; }

        public GetTestsByTestCollectionIdQuery(Guid testCollectionId)
        {
            TestCollectionId = testCollectionId;
        }
    }
}
