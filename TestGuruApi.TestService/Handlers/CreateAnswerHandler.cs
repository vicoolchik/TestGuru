using MediatR;
using TestGuruApi.DataService.Repositories.Interfaces;
using TestGuruApi.Entities.DbSet;
using TestGuruApi.Entities.Dto.Responses;
using TestGuruApi.TestService.Commands;
using AutoMapper;

namespace TestGuruApi.TestService.Handlers
{
    public class CreateAnswerHandler : IRequestHandler<CreateAnswerCommand, AnswerResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAnswerHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AnswerResponse> Handle(CreateAnswerCommand request, CancellationToken cancellationToken)
        {
            var answer = _mapper.Map<Answer>(request.AnswerRequest);
            await _unitOfWork.Answers.Add(answer);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<AnswerResponse>(answer);
        }
    }
}
