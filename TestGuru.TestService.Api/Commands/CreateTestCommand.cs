using MediatR;
using TestGuru.TestService.Contracts.Requests;
using TestGuru.TestService.Contracts.Responses;

namespace TestGuru.TestService.Api.Commands
{
    public class CreateTestCommand : IRequest<TestResponse>
    {
        public TestRequest TestRequest { get; set; }

        public CreateTestCommand(TestRequest testRequest)
        {
            TestRequest = testRequest;
        }
    }
}
