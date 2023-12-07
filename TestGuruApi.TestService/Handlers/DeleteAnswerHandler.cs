﻿using MediatR;
using TestGuruApi.DataService.Repositories.Interfaces;
using TestGuruApi.TestService.Commands;

namespace TestGuruApi.TestService.Handlers
{
    public class DeleteAnswerHandler : IRequestHandler<DeleteAnswerCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAnswerHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteAnswerCommand request, CancellationToken cancellationToken)
        {
            var success = await _unitOfWork.Answers.Delete(request.Id);
            if (!success)
            {
                throw new KeyNotFoundException("Answer not found");
            }
            await _unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }

}
