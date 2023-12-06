using MediatR;
using TestGuruApi.Entities.Dto.Responses;

namespace TestGuruApi.TestService.Queries
{
    public class GetQuestionByIdQuery : IRequest<QuestionResponse>
    {
        public Guid Id { get; }

        public GetQuestionByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
