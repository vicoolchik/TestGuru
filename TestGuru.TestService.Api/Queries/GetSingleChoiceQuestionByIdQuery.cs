using MediatR;
using TestGuru.TestService.Contracts.Responses;

namespace TestGuru.TestService.Api.Queries
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
