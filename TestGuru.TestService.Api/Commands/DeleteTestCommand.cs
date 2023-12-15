using MediatR;

namespace TestGuru.TestService.Api.Commands
{
    public class DeleteTestCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public DeleteTestCommand(Guid id)
        {
            Id = id;
        }
    }
}
