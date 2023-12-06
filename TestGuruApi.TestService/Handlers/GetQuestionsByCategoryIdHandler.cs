using AutoMapper;
using MediatR;
using TestGuruApi.DataService.Repositories.Interfaces;
using TestGuruApi.Entities.Dto.Responses;
using TestGuruApi.TestService.Queries;

namespace TestGuruApi.TestService.Handlers
{
    public class GetQuestionsByCategoryIdHandler : IRequestHandler<GetQuestionsByCategoryIdQuery, IEnumerable<QuestionResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetQuestionsByCategoryIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<QuestionResponse>> Handle(GetQuestionsByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var questions = await _unitOfWork.Questions.GetQuestionsByCategoryIdAsync(request.CategoryId);
            return _mapper.Map<IEnumerable<QuestionResponse>>(questions);
        }
    }
}
