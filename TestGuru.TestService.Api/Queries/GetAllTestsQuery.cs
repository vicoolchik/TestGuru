using MediatR;
using TestGuru.TestService.Contracts.Responses;

namespace TestGuru.TestService.Api.Queries
{
    public class GetAllTestsQuery : IRequest<IEnumerable<TestResponse>>
    {
    }
}
