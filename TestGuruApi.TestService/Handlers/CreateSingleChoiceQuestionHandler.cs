using AutoMapper;
using MediatR;
using TestGuruApi.DataService.Repositories.Interfaces;
using TestGuruApi.Entities.DbSet;
using TestGuruApi.Entities.Dto.Responses;
using TestGuruApi.TestService.Commands;

namespace TestGuruApi.TestService.Handlers
{
    public class CreateSingleChoiceQuestionHandler : IRequestHandler<CreateSingleChoiceQuestionCommand, SingleChoiceQuestionResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateSingleChoiceQuestionHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SingleChoiceQuestionResponse> Handle(CreateSingleChoiceQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = _mapper.Map<SingleChoiceQuestion>(request.QuestionRequest);
            await _unitOfWork.SingleChoiceQuestions.Add(question);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<SingleChoiceQuestionResponse>(question);
        }
    }
}
