using AutoMapper;
using MediatR;
using TestGuruApi.DataService.Repositories.Interfaces;
using TestGuruApi.Entities.Dto.Responses;
using TestGuruApi.TestService.Queries;

namespace TestGuruApi.TestService.Handlers
{
    public class GetSingleChoiceQuestionsByTestIdHandler : IRequestHandler<GetSingleChoiceQuestionsByTestIdQuery, IEnumerable<SingleChoiceQuestionResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSingleChoiceQuestionsByTestIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SingleChoiceQuestionResponse>> Handle(GetSingleChoiceQuestionsByTestIdQuery request, CancellationToken cancellationToken)
        {
            var questions = await _unitOfWork.SingleChoiceQuestions.GetByTestIdAsync(request.TestId);
            return _mapper.Map<IEnumerable<SingleChoiceQuestionResponse>>(questions);
        }
    }
}
