using MediatR;
using TestGuru.TestService.Contracts.Requests;

namespace TestGuru.TestService.Api.Commands
{
    public class UpdateSingleChoiceQuestionCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public SingleChoiceQuestionRequest QuestionRequest { get; set; }

        public UpdateSingleChoiceQuestionCommand(Guid id, SingleChoiceQuestionRequest questionRequest)
        {
            Id = id;
            QuestionRequest = questionRequest;
        }
    }
}
