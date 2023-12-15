using AutoMapper;
using MediatR;
using TestGuru.DAL.Repositories.Interfaces;
using TestGuru.TestService.Api.Commands;

namespace TestGuru.TestService.Api.Handlers
{
    public class UpdateTestHandler : IRequestHandler<UpdateTestCommand, Unit>
    {
        private readonly ITestRepository _repository;
        private readonly IMapper _mapper;

        public UpdateTestHandler(ITestRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTestCommand request, CancellationToken cancellationToken)
        {
            var test = await _repository.GetById(request.Id);
            if (test == null)
            {
                throw new KeyNotFoundException("Test not found");
            }

            _mapper.Map(request.TestRequest, test);
            await _repository.Update(test);

            return Unit.Value;
        }
    }
}
