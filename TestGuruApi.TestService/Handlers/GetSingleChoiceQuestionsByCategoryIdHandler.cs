using AutoMapper;
using MediatR;
using TestGuruApi.DataService.Repositories.Interfaces;
using TestGuruApi.Entities.Dto.Responses;
using TestGuruApi.TestService.Queries;

namespace TestGuruApi.TestService.Handlers
{
    public class GetSingleChoiceQuestionsByCategoryIdHandler : IRequestHandler<GetSingleChoiceQuestionsByCategoryIdQuery, IEnumerable<SingleChoiceQuestionResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSingleChoiceQuestionsByCategoryIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SingleChoiceQuestionResponse>> Handle(GetSingleChoiceQuestionsByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var questions = await _unitOfWork.SingleChoiceQuestions.GetByCategoryIdAsync(request.CategoryId);
            return _mapper.Map<IEnumerable<SingleChoiceQuestionResponse>>(questions);
        }
    }
}
