using MediatR;
using TestGuru.TestService.Contracts.Requests;

namespace TestGuru.TestService.Api.Commands
{
    public class UpdateTestCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public TestRequest TestRequest { get; set; }

        public UpdateTestCommand(Guid id, TestRequest testRequest)
        {
            Id = id;
            TestRequest = testRequest;
        }
    }
}
