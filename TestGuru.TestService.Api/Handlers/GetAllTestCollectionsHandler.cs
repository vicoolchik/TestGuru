using AutoMapper;
using MediatR;
using TestGuru.DAL.Repositories.Interfaces;
using TestGuru.TestService.Api.Queries;
using TestGuru.TestService.Contracts.Responses;

namespace TestGuru.TestService.Api.Handlers
{
    public class GetAllTestCollectionsHandler : IRequestHandler<GetAllTestCollectionsQuery, IEnumerable<TestCollectionResponse>>
    {
        private readonly ITestCollectionRepository _repository;
        private readonly IMapper _mapper;

        public GetAllTestCollectionsHandler(ITestCollectionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TestCollectionResponse>> Handle(GetAllTestCollectionsQuery request, CancellationToken cancellationToken)
        {
            var testCollections = await _repository.GetAllWithTestsAsync();
            return _mapper.Map<IEnumerable<TestCollectionResponse>>(testCollections);
        }
    }
}
