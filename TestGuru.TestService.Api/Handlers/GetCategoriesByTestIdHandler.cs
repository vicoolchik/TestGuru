using AutoMapper;
using MediatR;
using TestGuru.DAL.Repositories.Interfaces;
using TestGuru.TestService.Api.Queries;
using TestGuru.TestService.Contracts.Responses;

namespace TestGuru.TestService.Api.Handlers
{
    public class GetCategoriesByTestIdHandler : IRequestHandler<GetCategoriesByTestIdQuery, IEnumerable<CategoryResponse>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoriesByTestIdHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryResponse>> Handle(GetCategoriesByTestIdQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllByTestIdAsync(request.TestId);
            return _mapper.Map<IEnumerable<CategoryResponse>>(categories);
        }
    }
}
