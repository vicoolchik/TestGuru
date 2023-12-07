using MediatR;
using TestGuruApi.DataService.Repositories.Interfaces;
using TestGuruApi.TestService.Commands;

namespace TestGuruApi.TestService.Handlers
{
    public class DeleteSingleChoiceQuestionHandler : IRequestHandler<DeleteSingleChoiceQuestionCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSingleChoiceQuestionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteSingleChoiceQuestionCommand request, CancellationToken cancellationToken)
        {
            var success = await _unitOfWork.SingleChoiceQuestions.Delete(request.Id);
            if (!success)
            {
                throw new KeyNotFoundException("Question not found");
            }
            await _unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}
