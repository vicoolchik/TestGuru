using AutoMapper;
using MediatR;
using TestGuruApi.DataService.Repositories.Interfaces;
using TestGuruApi.Entities.Dto.Responses;
using TestGuruApi.TestService.Queries;

namespace TestGuruApi.TestService.Handlers
{
    public class GetAnswerByIdHandler : IRequestHandler<GetAnswerByIdQuery, AnswerResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAnswerByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AnswerResponse> Handle(GetAnswerByIdQuery request, CancellationToken cancellationToken)
        {
            var answer = await _unitOfWork.Answers.GetById(request.Id);
            return answer != null ? _mapper.Map<AnswerResponse>(answer) : null;
        }
    }
}
