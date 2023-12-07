using AutoMapper;
using MediatR;
using TestGuruApi.DataService.Repositories.Interfaces;
using TestGuruApi.TestService.Commands;

namespace TestGuruApi.TestService.Handlers
{
    public class UpdateSingleChoiceQuestionHandler : IRequestHandler<UpdateSingleChoiceQuestionCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSingleChoiceQuestionHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateSingleChoiceQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = await _unitOfWork.SingleChoiceQuestions.GetById(request.Id);
            if (question == null)
            {
                throw new KeyNotFoundException("Question not found");
            }

            _mapper.Map(request.QuestionRequest, question);
            await _unitOfWork.SingleChoiceQuestions.Update(question);
            await _unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}
