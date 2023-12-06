using AutoMapper;
using MediatR;
using TestGuruApi.DataService.Repositories.Interfaces;
using TestGuruApi.Entities.Dto.Responses;
using TestGuruApi.TestService.Queries;

namespace TestGuruApi.TestService.Handlers
{
    public class GetQuestionsByTestIdHandler : IRequestHandler<GetQuestionsByTestIdQuery, IEnumerable<QuestionResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetQuestionsByTestIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<QuestionResponse>> Handle(GetQuestionsByTestIdQuery request, CancellationToken cancellationToken)
        {
            var questions = await _unitOfWork.Questions.GetQuestionsByTestIdAsync(request.TestId);
            return _mapper.Map<IEnumerable<QuestionResponse>>(questions);
        }
    }
}
