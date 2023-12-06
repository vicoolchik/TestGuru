using MediatR;

namespace TestGuruApi.TestService.Commands
{
    public class DeleteQuestionCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public DeleteQuestionCommand(Guid id)
        {
            Id = id;
        }
    }
}
