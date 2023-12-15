using AutoMapper;
using MediatR;
using TestGuru.DAL.Repositories.Interfaces;
using TestGuru.TestService.Api.Commands;

namespace TestGuru.TestService.Api.Handlers
{
    public class UpdateTestCollectionHandler : IRequestHandler<UpdateTestCollectionCommand, Unit>
    {
        private readonly ITestCollectionRepository _repository;
        private readonly IMapper _mapper;

        public UpdateTestCollectionHandler(ITestCollectionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTestCollectionCommand request, CancellationToken cancellationToken)
        {
            var testCollection = await _repository.GetById(request.Id);
            if (testCollection == null)
            {
                throw new KeyNotFoundException("TestCollection not found");
            }

            _mapper.Map(request.TestCollectionRequest, testCollection);
            await _repository.Update(testCollection);

            return Unit.Value;
        }
    }
}
