using AutoMapper;
using MediatR;
using TestGuru.DAL.Repositories.Interfaces;
using TestGuru.TestService.Api.Commands;

namespace TestGuru.TestService.Api.Handlers
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetById(request.Id);
            if (category == null)
            {
                throw new KeyNotFoundException("Category not found");
            }

            _mapper.Map(request.CategoryRequest, category);
            await _categoryRepository.Update(category);

            return Unit.Value;
        }
    }
}
