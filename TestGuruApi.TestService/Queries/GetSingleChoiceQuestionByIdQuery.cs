using MediatR;
using TestGuruApi.Entities.Dto.Responses;

namespace TestGuruApi.TestService.Queries
{
    public class GetSingleChoiceQuestionByIdQuery : IRequest<SingleChoiceQuestionResponse>
    {
        public Guid Id { get; }

        public GetSingleChoiceQuestionByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
