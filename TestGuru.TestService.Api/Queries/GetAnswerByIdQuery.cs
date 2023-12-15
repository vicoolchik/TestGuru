using MediatR;
using TestGuru.TestService.Contracts.Responses;

namespace TestGuru.TestService.Api.Queries
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
