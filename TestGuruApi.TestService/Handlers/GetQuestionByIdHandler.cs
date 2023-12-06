using AutoMapper;
using MediatR;
using TestGuruApi.DataService.Repositories.Interfaces;
using TestGuruApi.Entities.Dto.Responses;
using TestGuruApi.TestService.Queries;

namespace TestGuruApi.TestService.Handlers
{
    public class GetQuestionByIdHandler : IRequestHandler<GetQuestionByIdQuery, QuestionResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetQuestionByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<QuestionResponse> Handle(GetQuestionByIdQuery request, CancellationToken cancellationToken)
        {
            var question = await _unitOfWork.Questions.GetById(request.Id);
            return question != null ? _mapper.Map<QuestionResponse>(question) : null;
        }
    }
}
