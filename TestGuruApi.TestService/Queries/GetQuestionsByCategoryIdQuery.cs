using MediatR;
using TestGuruApi.Entities.Dto.Responses;

namespace TestGuruApi.TestService.Queries
{
    public class GetQuestionsByCategoryIdQuery : IRequest<IEnumerable<QuestionResponse>>
    {
        public Guid CategoryId { get; set; }

        public GetQuestionsByCategoryIdQuery(Guid categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
