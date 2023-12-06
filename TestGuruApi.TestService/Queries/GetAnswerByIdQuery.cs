using MediatR;
using TestGuruApi.Entities.Dto.Responses;

namespace TestGuruApi.TestService.Queries
{
    public class GetAnswerByIdQuery : IRequest<AnswerResponse>
    {
        public Guid Id { get; set; }

        public GetAnswerByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
