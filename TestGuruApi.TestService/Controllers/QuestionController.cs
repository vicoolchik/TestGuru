using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestGuruApi.DataService.Repositories.Interfaces;
using TestGuruApi.Entities.Dto.Requests;
using TestGuruApi.Entities.Dto.Responses;
using TestGuruApi.TestService.Commands;
using TestGuruApi.TestService.Queries;

namespace TestGuruApi.TestService.Controllers
{
    public class QuestionController : BaseController
    {
        public QuestionController(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator) : base(unitOfWork, mapper, mediator)
        {
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionResponse>> GetQuestion(Guid id)
        {
            var question = await _mediator.Send(new GetQuestionByIdQuery(id));
            if (question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }

        [HttpGet("by-category/{categoryId}")]
        public async Task<ActionResult<IEnumerable<QuestionResponse>>> GetQuestionsByCategory(Guid categoryId)
        {
            var questions = await _mediator.Send(new GetQuestionsByCategoryIdQuery(categoryId));
            return Ok(questions);
        }

        [HttpGet("by-test/{testId}")]
        public async Task<ActionResult<IEnumerable<QuestionResponse>>> GetQuestionsByTest(Guid testId)
        {
            var questions = await _mediator.Send(new GetQuestionsByTestIdQuery(testId));
            return Ok(questions);
        }

        [HttpPost]
        public async Task<ActionResult<QuestionResponse>> CreateQuestion([FromBody] QuestionRequest questionRequest)
        {
            var question = await _mediator.Send(new CreateQuestionCommand(questionRequest));
            return CreatedAtAction(nameof(GetQuestion), new { id = question.Id }, question);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion(Guid id, [FromBody] QuestionRequest questionRequest)
        {
            await _mediator.Send(new UpdateQuestionCommand(id, questionRequest));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(Guid id)
        {
            await _mediator.Send(new DeleteQuestionCommand(id));
            return NoContent();
        }
    }
}
