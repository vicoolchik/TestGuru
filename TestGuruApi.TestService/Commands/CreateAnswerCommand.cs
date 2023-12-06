using MediatR;
using TestGuruApi.Entities.Dto.Requests;
using TestGuruApi.Entities.Dto.Responses;

namespace TestGuruApi.TestService.Commands
{
    public class CreateAnswerCommand : IRequest<AnswerResponse>
    {
        public AnswerRequest AnswerRequest { get; set; }

        public CreateAnswerCommand(AnswerRequest answerRequest)
        {
            AnswerRequest = answerRequest;
        }
    }
}
