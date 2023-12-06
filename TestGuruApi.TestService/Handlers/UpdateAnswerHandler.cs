using AutoMapper;
using MediatR;
using TestGuruApi.DataService.Repositories.Interfaces;
using TestGuruApi.TestService.Commands;

namespace TestGuruApi.TestService.Handlers
{
    public class UpdateAnswerHandler : IRequestHandler<UpdateAnswerCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAnswerHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAnswerCommand request, CancellationToken cancellationToken)
        {
            var answer = await _unitOfWork.Answers.GetById(request.Id);
            if (answer == null)
            {
                throw new KeyNotFoundException("Answer not found");
            }

            _mapper.Map(request.AnswerRequest, answer);
            _unitOfWork.Answers.Update(answer);
            await _unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }

}
