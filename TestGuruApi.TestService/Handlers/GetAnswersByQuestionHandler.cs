using AutoMapper;
using MediatR;
using TestGuruApi.DataService.Repositories.Interfaces;
using TestGuruApi.Entities.Dto.Responses;
using TestGuruApi.TestService.Queries;

namespace TestGuruApi.TestService.Handlers
{
    public class GetAnswersByQuestionHandler : IRequestHandler<GetAnswersByQuestionQuery, IEnumerable<AnswerResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAnswersByQuestionHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AnswerResponse>> Handle(GetAnswersByQuestionQuery request, CancellationToken cancellationToken)
        {
            var answers = await _unitOfWork.Answers.GetAllByQuestionIdAsync(request.QuestionId);
            return _mapper.Map<IEnumerable<AnswerResponse>>(answers);
        }
    }
}
