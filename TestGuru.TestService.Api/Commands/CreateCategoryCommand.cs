using MediatR;
using TestGuru.TestService.Contracts.Requests;
using TestGuru.TestService.Contracts.Responses;

namespace TestGuru.TestService.Api.Commands
{
    public class CreateCategoryCommand : IRequest<CategoryResponse>
    {
        public CategoryRequest CategoryRequest { get; set; }

        public CreateCategoryCommand(CategoryRequest categoryRequest)
        {
            CategoryRequest = categoryRequest;
        }
    }
}
