using AutoMapper;
using MediatR;
using TestGuruApi.DataService.Repositories.Interfaces;
using TestGuruApi.Entities.Dto.Responses;
using TestGuruApi.TestService.Queries;

namespace TestGuruApi.TestService.Handlers
{
    public class GetSingleChoiceQuestionByIdHandler : IRequestHandler<GetSingleChoiceQuestionByIdQuery, SingleChoiceQuestionResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSingleChoiceQuestionByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SingleChoiceQuestionResponse> Handle(GetSingleChoiceQuestionByIdQuery request, CancellationToken cancellationToken)
        {
            var question = await _unitOfWork.SingleChoiceQuestions.GetById(request.Id);
            return question != null ? _mapper.Map<SingleChoiceQuestionResponse>(question) : null;
        }
    }
}
