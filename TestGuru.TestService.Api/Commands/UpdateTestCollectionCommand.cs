using MediatR;
using TestGuru.TestService.Contracts.Requests;

namespace TestGuru.TestService.Api.Commands
{
    public class UpdateTestCollectionCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public TestCollectionRequest TestCollectionRequest { get; set; }

        public UpdateTestCollectionCommand(Guid id, TestCollectionRequest testCollectionRequest)
        {
            Id = id;
            TestCollectionRequest = testCollectionRequest;
        }
    }
}
