using AutoMapper;
using MediatR;
using TestGuru.DAL.Repositories.Interfaces;
using TestGuru.Domain.Entities;
using TestGuru.TestService.Api.Commands;
using TestGuru.TestService.Contracts.Responses;

namespace TestGuru.TestService.Api.Handlers
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, CategoryResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request.CategoryRequest);
            await _categoryRepository.Add(category);

            return _mapper.Map<CategoryResponse>(category);
        }
    }
}
