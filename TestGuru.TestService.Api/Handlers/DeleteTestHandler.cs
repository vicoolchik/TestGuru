using MediatR;
using TestGuru.DAL.Repositories.Interfaces;
using TestGuru.TestService.Api.Commands;

namespace TestGuru.TestService.Api.Handlers
{
    public class DeleteTestHandler : IRequestHandler<DeleteTestCommand, Unit>
    {
        private readonly ITestRepository _repository;

        public DeleteTestHandler(ITestRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteTestCommand request, CancellationToken cancellationToken)
        {
            var success = await _repository.Delete(request.Id);
            if (!success)
            {
                throw new KeyNotFoundException("Test not found");
            }

            return Unit.Value;
        }
    }
}
