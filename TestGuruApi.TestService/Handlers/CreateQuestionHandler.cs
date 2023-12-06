using AutoMapper;
using MediatR;
using TestGuruApi.DataService.Repositories.Interfaces;
using TestGuruApi.Entities.DbSet;
using TestGuruApi.Entities.Dto.Responses;
using TestGuruApi.TestService.Commands;

namespace TestGuruApi.TestService.Handlers
{
    public class CreateQuestionHandler : IRequestHandler<CreateQuestionCommand, QuestionResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateQuestionHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<QuestionResponse> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = _mapper.Map<Question>(request.QuestionRequest);
            _unitOfWork.Questions.Add(question);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<QuestionResponse>(question);
        }
    }
}
