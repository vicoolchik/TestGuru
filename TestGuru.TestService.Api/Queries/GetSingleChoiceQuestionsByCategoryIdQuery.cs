using MediatR;
using TestGuru.TestService.Contracts.Responses;

namespace TestGuru.TestService.Api.Queries
{
    public class GetSingleChoiceQuestionsByCategoryIdQuery : IRequest<IEnumerable<SingleChoiceQuestionResponse>>
    {
        public Guid CategoryId { get; set; }

        public GetSingleChoiceQuestionsByCategoryIdQuery(Guid categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
