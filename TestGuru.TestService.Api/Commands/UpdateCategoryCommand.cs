using MediatR;
using TestGuru.TestService.Contracts.Requests;

namespace TestGuru.TestService.Api.Commands
{
    public class UpdateCategoryCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public CategoryRequest CategoryRequest { get; set; }

        public UpdateCategoryCommand(Guid id, CategoryRequest categoryRequest)
        {
            Id = id;
            CategoryRequest = categoryRequest;
        }
    }
}
