using MediatR;
using TestGuru.TestService.Contracts.Responses;

namespace TestGuru.TestService.Api.Queries
{
    public class GetTestCollectionByIdQuery : IRequest<TestCollectionResponse>
    {
        public Guid Id { get; private set; }

        public GetTestCollectionByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
