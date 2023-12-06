using MediatR;
using TestGuruApi.Entities.Dto.Requests;

namespace TestGuruApi.TestService.Commands
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
