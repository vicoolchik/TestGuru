using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestGuru.TestService.Api.Commands;
using TestGuru.TestService.Api.Queries;
using TestGuru.TestService.Contracts.Requests;
using TestGuru.TestService.Contracts.Responses;

namespace TestGuru.TestService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : BaseController
    {
        public CategoryController(IMapper mapper, IMediator mediator) : base(mapper, mediator)
        {
        }

        [HttpGet]

        [HttpGet("test/{testId}")]
        public async Task<ActionResult<IEnumerable<CategoryResponse>>> GetCategoriesByTest(Guid testId)
        {
            var categories = await _mediator.Send(new GetCategoriesByTestIdQuery(testId));
            return categories.Any() ? Ok(categories) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryResponse>> GetCategory(Guid id)
        {
            var category = await _mediator.Send(new GetCategoryByIdQuery(id));
            return category != null ? Ok(category) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<CategoryResponse>> CreateCategory([FromBody] CategoryRequest categoryRequest)
        {
            var categoryResponse = await _mediator.Send(new CreateCategoryCommand(categoryRequest));
            return CreatedAtAction(nameof(GetCategory), new { id = categoryResponse.Id }, categoryResponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(Guid id, [FromBody] CategoryRequest categoryRequest)
        {
            await _mediator.Send(new UpdateCategoryCommand(id, categoryRequest));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            await _mediator.Send(new DeleteCategoryCommand(id));
            return NoContent();
        }
    }
}
