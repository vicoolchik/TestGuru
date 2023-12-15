using AutoMapper;
using MediatR;
using TestGuru.DAL.Repositories.Interfaces;
using TestGuru.Domain.Entities;
using TestGuru.TestService.Api.Commands;
using TestGuru.TestService.Contracts.Responses;

namespace TestGuru.TestService.Api.Handlers
{
    public class CreateTestCollectionHandler : IRequestHandler<CreateTestCollectionCommand, TestCollectionResponse>
    {
        private readonly ITestCollectionRepository _repository;
        private readonly IMapper _mapper;

        public CreateTestCollectionHandler(ITestCollectionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TestCollectionResponse> Handle(CreateTestCollectionCommand request, CancellationToken cancellationToken)
        {
            var testCollection = _mapper.Map<TestCollection>(request.TestCollectionRequest);
            await _repository.Add(testCollection);

            return _mapper.Map<TestCollectionResponse>(testCollection);
        }
    }
}
