using MediatR;
using TestGuru.TestService.Contracts.Requests;
using TestGuru.TestService.Contracts.Responses;

namespace TestGuru.TestService.Api.Commands
{
    public class CreateTestCollectionCommand : IRequest<TestCollectionResponse>
    {
        public TestCollectionRequest TestCollectionRequest { get; set; }

        public CreateTestCollectionCommand(TestCollectionRequest testCollectionRequest)
        {
            TestCollectionRequest = testCollectionRequest;
        }
    }
}
