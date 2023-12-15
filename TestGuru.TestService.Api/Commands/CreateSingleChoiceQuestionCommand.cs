using MediatR;
using TestGuru.TestService.Contracts.Requests;
using TestGuru.TestService.Contracts.Responses;

namespace TestGuru.TestService.Api.Commands
{
    public class CreateSingleChoiceQuestionCommand : IRequest<SingleChoiceQuestionResponse>
    {
        public SingleChoiceQuestionRequest QuestionRequest { get; set; }

        public CreateSingleChoiceQuestionCommand(SingleChoiceQuestionRequest questionRequest)
        {
            QuestionRequest = questionRequest;
        }
    }
}
