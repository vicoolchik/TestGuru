using MediatR;
using TestGuruApi.Entities.Dto.Responses;

namespace TestGuruApi.TestService.Queries
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
