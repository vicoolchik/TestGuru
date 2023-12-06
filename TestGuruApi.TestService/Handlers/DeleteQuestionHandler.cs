using MediatR;
using TestGuruApi.DataService.Repositories.Interfaces;
using TestGuruApi.TestService.Commands;

namespace TestGuruApi.TestService.Handlers
{
    public class DeleteQuestionHandler : IRequestHandler<DeleteQuestionCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteQuestionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            var success = await _unitOfWork.Questions.Delete(request.Id);
            if (!success)
            {
                throw new KeyNotFoundException("Question not found");
            }
            await _unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}
