using MediatR;

namespace TestGuruApi.TestService.Commands
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
