using MediatR;
using TestGuru.TestService.Contracts.Responses;

namespace TestGuru.TestService.Api.Queries
{
    public class GetTestByIdQuery : IRequest<TestResponse>
    {
        public Guid Id { get; set; }

        public GetTestByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
