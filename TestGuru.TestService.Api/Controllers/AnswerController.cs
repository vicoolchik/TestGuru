using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestGuru.DAL.Repositories.Interfaces;
using TestGuru.TestService.Api.Commands;
using TestGuru.TestService.Api.Queries;
using TestGuru.TestService.Contracts.Requests;
using TestGuru.TestService.Contracts.Responses;

namespace TestGuru.TestService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnswerController : BaseController
    {
        public AnswerController( IMapper mapper, IMediator mediator) : base(mapper, mediator)
        {
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AnswerResponse>> GetAnswer(Guid id)
        {
            var answer = await _mediator.Send(new GetAnswerByIdQuery(id));
            return answer != null ? Ok(answer) : NotFound();
        }

        [HttpGet("Question/{questionId}")]
        public async Task<ActionResult<IEnumerable<AnswerResponse>>> GetAnswersByQuestion(Guid questionId)
        {
            var answers = await _mediator.Send(new GetAnswersByQuestionQuery(questionId));
            if (answers == null || !answers.Any())
            {
                return NotFound();
            }
            return Ok(answers);
        }

        [HttpPost]
        public async Task<ActionResult<AnswerResponse>> CreateAnswer([FromBody] AnswerRequest answerRequest)
        {
            var answerResponse = await _mediator.Send(new CreateAnswerCommand(answerRequest));
            return CreatedAtAction(nameof(GetAnswer), new { id = answerResponse.Id }, answerResponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnswer(Guid id, [FromBody] AnswerRequest answerRequest)
        {
            await _mediator.Send(new UpdateAnswerCommand(id, answerRequest));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnswer(Guid id)
        {
            await _mediator.Send(new DeleteAnswerCommand(id));
            return NoContent();
        }
    }
}
