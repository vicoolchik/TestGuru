using MediatR;
using TestGuruApi.Entities.Dto.Requests;
using TestGuruApi.Entities.Dto.Responses;

namespace TestGuruApi.TestService.Commands
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
