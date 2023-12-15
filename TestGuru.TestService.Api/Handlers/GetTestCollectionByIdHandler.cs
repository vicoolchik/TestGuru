using AutoMapper;
using MediatR;
using TestGuru.DAL.Repositories.Interfaces;
using TestGuru.TestService.Api.Queries;
using TestGuru.TestService.Contracts.Responses;

namespace TestGuru.TestService.Api.Handlers
{
    public class GetTestCollectionByIdHandler : IRequestHandler<GetTestCollectionByIdQuery, TestCollectionResponse>
    {
        private readonly ITestCollectionRepository _testCollectionRepository;
        private readonly IMapper _mapper;

        public GetTestCollectionByIdHandler(ITestCollectionRepository testCollectionRepository, IMapper mapper)
        {
            _testCollectionRepository = testCollectionRepository;
            _mapper = mapper;
        }

        public async Task<TestCollectionResponse> Handle(GetTestCollectionByIdQuery request, CancellationToken cancellationToken)
        {
            var testCollection = await _testCollectionRepository.GetById(request.Id);
            if (testCollection == null)
            {
                throw new KeyNotFoundException($"TestCollection with ID {request.Id} not found");
            }

            return _mapper.Map<TestCollectionResponse>(testCollection);
        }
    }
}
