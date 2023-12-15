using MediatR;
using TestGuru.TestService.Contracts.Requests;

namespace TestGuru.TestService.Api.Commands
{
    public class UpdateAnswerCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public AnswerRequest AnswerRequest { get; set; }

        public UpdateAnswerCommand(Guid id, AnswerRequest answerRequest)
        {
            Id = id;
            AnswerRequest = answerRequest;
        }
    }
}
