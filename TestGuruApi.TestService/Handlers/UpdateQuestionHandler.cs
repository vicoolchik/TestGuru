using AutoMapper;
using MediatR;
using TestGuruApi.DataService.Repositories.Interfaces;
using TestGuruApi.TestService.Commands;

namespace TestGuruApi.TestService.Handlers
{
    public class UpdateQuestionHandler : IRequestHandler<UpdateQuestionCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateQuestionHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = await _unitOfWork.Questions.GetById(request.Id);
            if (question == null)
            {
                throw new KeyNotFoundException("Question not found.");
            }

            _mapper.Map(request.QuestionRequest, question);
            _unitOfWork.Questions.Update(question);
            await _unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}
