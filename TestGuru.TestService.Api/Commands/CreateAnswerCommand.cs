using MediatR;
using TestGuru.TestService.Contracts.Requests;
using TestGuru.TestService.Contracts.Responses;

namespace TestGuru.TestService.Api.Commands
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
