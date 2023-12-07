using MediatR;
using TestGuruApi.Entities.Dto.Requests;

namespace TestGuruApi.TestService.Commands
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
