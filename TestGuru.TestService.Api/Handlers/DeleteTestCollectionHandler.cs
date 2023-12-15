using MediatR;
using TestGuru.DAL.Repositories.Interfaces;
using TestGuru.TestService.Api.Commands;

namespace TestGuru.TestService.Api.Handlers
{
    public class DeleteTestCollectionHandler : IRequestHandler<DeleteTestCollectionCommand, Unit>
    {
        private readonly ITestCollectionRepository _repository;

        public DeleteTestCollectionHandler(ITestCollectionRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteTestCollectionCommand request, CancellationToken cancellationToken)
        {
            var success = await _repository.Delete(request.Id);
            if (!success)
            {
                throw new KeyNotFoundException("TestCollection not found");
            }

            return Unit.Value;
        }
    }
}
