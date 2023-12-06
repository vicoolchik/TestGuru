using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestGuruApi.DataService.Repositories.Interfaces;
using TestGuruApi.Entities.DbSet;
using TestGuruApi.Entities.Dto.Requests;
using TestGuruApi.Entities.Dto.Responses;
using TestGuruApi.TestService.Controllers;

namespace TestGuruApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : BaseController
    {
        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator) : base(unitOfWork, mapper, mediator)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryResponse>>> GetAllCategories()
        {
            var categories = await _unitOfWork.Categories.All();
            var categoryDtos = _mapper.Map<IEnumerable<CategoryResponse>>(categories);
            return Ok(categoryDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryResponse>> GetCategory(Guid id)
        {
            var category = await _unitOfWork.Categories.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            var categoryDto = _mapper.Map<CategoryResponse>(category);
            return Ok(categoryDto);
        }

        [HttpGet("test/{testId}")]
        public async Task<ActionResult<IEnumerable<CategoryResponse>>> GetCategoriesByTest(Guid testId)
        {
            var categories = await _unitOfWork.Categories.GetAllByTestIdAsync(testId);
            if (categories == null || !categories.Any())
            {
                return NotFound();
            }
            var categoryDtos = _mapper.Map<IEnumerable<CategoryResponse>>(categories);
            return Ok(categoryDtos);
        }


        [HttpPost]
        public async Task<ActionResult<CategoryResponse>> CreateCategory([FromBody] CategoryRequest categoryRequestDto)
        {
            var category = _mapper.Map<Category>(categoryRequestDto);
            await _unitOfWork.Categories.Add(category);
            await _unitOfWork.CompleteAsync();

            var categoryDto = _mapper.Map<CategoryResponse>(category);
            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, categoryDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(Guid id, [FromBody] CategoryRequest categoryRequestDto)
        {
            var category = await _unitOfWork.Categories.GetById(id);
            if (category == null)
            {
                return NotFound();
            }

            _mapper.Map(categoryRequestDto, category);
            await _unitOfWork.Categories.Update(category);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var success = await _unitOfWork.Categories.Delete(id);
            if (!success)
            {
                return NotFound();
            }
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }
    }
}
