using AutoMapper;
using MediatR;
using TestGuru.DAL.Repositories.Interfaces;
using TestGuru.TestService.Api.Queries;
using TestGuru.TestService.Contracts.Responses;

namespace TestGuru.TestService.Api.Handlers
{
    public class GetAllTestsHandler : IRequestHandler<GetAllTestsQuery, IEnumerable<TestResponse>>
    {
        private readonly ITestRepository _repository;
        private readonly IMapper _mapper;

        public GetAllTestsHandler(ITestRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TestResponse>> Handle(GetAllTestsQuery request, CancellationToken cancellationToken)
        {
            var tests = await _repository.All();
            return _mapper.Map<IEnumerable<TestResponse>>(tests);
        }
    }
}
