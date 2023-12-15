using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestGuru.TestService.Api.Commands;
using TestGuru.TestService.Api.Queries;
using TestGuru.TestService.Contracts.Requests;


namespace TestGuru.TestService.Api.Controllers
{
    public class SingleChoiceQuestionController : BaseController
    {
        public SingleChoiceQuestionController(IMapper mapper, IMediator mediator)
            : base( mapper, mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreateSingleChoiceQuestion([FromBody] SingleChoiceQuestionRequest request)
        {
            var command = new CreateSingleChoiceQuestionCommand(request);
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleChoiceQuestion(Guid id)
        {
            var query = new GetSingleChoiceQuestionByIdQuery(id);
            var response = await _mediator.Send(query);
            if (response == null) return NotFound();
            return Ok(response);
        }

        [HttpGet("Test/{testId}")]
        public async Task<IActionResult> GetSingleChoiceQuestionByTestId(Guid testId)
        {
            var query = new GetSingleChoiceQuestionsByTestIdQuery(testId);
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("Category/{categoryId}")]
        public async Task<IActionResult> GetSingleChoiceQuestionByCategoryId(Guid categoryId)
        {
            var query = new GetSingleChoiceQuestionsByCategoryIdQuery(categoryId);
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSingleChoiceQuestion(Guid id, [FromBody] SingleChoiceQuestionRequest request)
        {
            var command = new UpdateSingleChoiceQuestionCommand(id, request);
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSingleChoiceQuestion(Guid id)
        {
            var command = new DeleteSingleChoiceQuestionCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
