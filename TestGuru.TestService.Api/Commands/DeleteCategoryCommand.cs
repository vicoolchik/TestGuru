using MediatR;

namespace TestGuru.TestService.Api.Commands
{
    public class DeleteCategoryCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public DeleteCategoryCommand(Guid id)
        {
            Id = id;
        }
    }
}
