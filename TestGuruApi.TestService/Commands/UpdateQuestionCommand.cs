using MediatR;
using TestGuruApi.Entities.Dto.Requests;

namespace TestGuruApi.TestService.Commands
{
    public class UpdateQuestionCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public QuestionRequest QuestionRequest { get; set; }

        public UpdateQuestionCommand(Guid id, QuestionRequest questionRequest)
        {
            Id = id;
            QuestionRequest = questionRequest;
        }
    }
}
