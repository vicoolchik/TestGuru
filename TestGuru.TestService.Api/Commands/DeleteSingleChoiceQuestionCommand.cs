using MediatR;

namespace TestGuru.TestService.Api.Commands
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
