using AutoMapper;
using MediatR;
using TestGuru.DAL.Repositories.Interfaces;
using TestGuru.TestService.Api.Queries;
using TestGuru.TestService.Contracts.Responses;

namespace TestGuru.TestService.Api.Handlers
{
    public class GetTestByIdHandler : IRequestHandler<GetTestByIdQuery, TestResponse>
    {
        private readonly ITestRepository _repository;
        private readonly IMapper _mapper;

        public GetTestByIdHandler(ITestRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TestResponse> Handle(GetTestByIdQuery request, CancellationToken cancellationToken)
        {
            var test = await _repository.GetById(request.Id);
            if (test == null)
            {
                throw new KeyNotFoundException("Test not found");
            }

            return _mapper.Map<TestResponse>(test);
        }
    }
}
