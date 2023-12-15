using AutoMapper;
using MediatR;
using TestGuru.DAL.Repositories.Interfaces;
using TestGuru.Domain.Entities;
using TestGuru.TestService.Api.Commands;
using TestGuru.TestService.Contracts.Responses;

namespace TestGuru.TestService.Api.Handlers
{
    public class CreateAnswerHandler : IRequestHandler<CreateAnswerCommand, AnswerResponse>
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IMapper _mapper;

        public CreateAnswerHandler(IAnswerRepository answerRepository, IMapper mapper)
        {
            _answerRepository = answerRepository;
            _mapper = mapper;
        }

        public async Task<AnswerResponse> Handle(CreateAnswerCommand request, CancellationToken cancellationToken)
        {
            var answer = _mapper.Map<Answer>(request.AnswerRequest);
            await _answerRepository.Add(answer);

            return _mapper.Map<AnswerResponse>(answer);
        }
    }
}
