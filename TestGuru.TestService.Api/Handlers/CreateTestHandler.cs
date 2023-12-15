using AutoMapper;
using MediatR;
using TestGuru.DAL.Repositories.Interfaces;
using TestGuru.Domain.Entities;
using TestGuru.TestService.Api.Commands;
using TestGuru.TestService.Contracts.Responses;

namespace TestGuru.TestService.Api.Handlers
{
    public class CreateTestHandler : IRequestHandler<CreateTestCommand, TestResponse>
    {
        private readonly ITestRepository _repository;
        private readonly IMapper _mapper;

        public CreateTestHandler(ITestRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TestResponse> Handle(CreateTestCommand request, CancellationToken cancellationToken)
        {
            var test = _mapper.Map<Test>(request.TestRequest);
            await _repository.Add(test);

            return _mapper.Map<TestResponse>(test);
        }
    }
}
