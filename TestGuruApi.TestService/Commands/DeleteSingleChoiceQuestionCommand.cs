using MediatR;

namespace TestGuruApi.TestService.Commands
{
    public class DeleteSingleChoiceQuestionCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public DeleteSingleChoiceQuestionCommand(Guid id)
        {
            Id = id;
        }
    }
}
