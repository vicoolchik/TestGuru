using MediatR;

namespace TestGuru.TestService.Api.Commands
{
    public class DeleteAnswerCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public DeleteAnswerCommand(Guid id)
        {
            Id = id;
        }
    }
}
