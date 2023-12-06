using MediatR;
using TestGuruApi.Entities.Dto.Requests;
using TestGuruApi.Entities.Dto.Responses;

namespace TestGuruApi.TestService.Commands
{
    public class CreateQuestionCommand : IRequest<QuestionResponse>
    {
        public QuestionRequest QuestionRequest { get; set; }

        public CreateQuestionCommand(QuestionRequest questionRequest)
        {
            QuestionRequest = questionRequest;
        }
    }
}
