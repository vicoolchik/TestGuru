using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestGuruApi.DataService.Repositories.Interfaces;
using TestGuruApi.Entities.Dto.Requests;
using TestGuruApi.TestService.Commands;
using TestGuruApi.TestService.Queries;

namespace TestGuruApi.TestService.Controllers
{
    public class SingleChoiceQuestionController : BaseController
    {
        public SingleChoiceQuestionController(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator)
            : base(unitOfWork, mapper, mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SingleChoiceQuestionRequest request)
        {
            var command = new CreateSingleChoiceQuestionCommand(request);
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetSingleChoiceQuestionByIdQuery(id);
            var response = await _mediator.Send(query);
            if (response == null) return NotFound();
            return Ok(response);
        }

        [HttpGet("Test/{testId}")]
        public async Task<IActionResult> GetByTestId(Guid testId)
        {
            var query = new GetSingleChoiceQuestionsByTestIdQuery(testId);
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("Category/{categoryId}")]
        public async Task<IActionResult> GetByCategoryId(Guid categoryId)
        {
            var query = new GetSingleChoiceQuestionsByCategoryIdQuery(categoryId);
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] SingleChoiceQuestionRequest request)
        {
            var command = new UpdateSingleChoiceQuestionCommand(id, request);
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteSingleChoiceQuestionCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
