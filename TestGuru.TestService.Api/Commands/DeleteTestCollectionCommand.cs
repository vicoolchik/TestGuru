using MediatR;

namespace TestGuru.TestService.Api.Commands
{
    public class DeleteTestCollectionCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public DeleteTestCollectionCommand(Guid id)
        {
            Id = id;
        }
    }
}
