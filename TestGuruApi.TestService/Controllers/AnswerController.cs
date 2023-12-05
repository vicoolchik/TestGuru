using AutoMapper;
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
    public class AnswerController : BaseController
    {
        public AnswerController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AnswerResponse>> GetAnswer(Guid id)
        {
            var answer = await _unitOfWork.Answers.GetById(id);
            if (answer == null)
            {
                return NotFound();
            }
            var answerResponse = _mapper.Map<AnswerResponse>(answer);
            return Ok(answerResponse);
        }

        [HttpGet("question/{questionId}")]
        public async Task<ActionResult<IEnumerable<AnswerResponse>>> GetAnswersByQuestion(Guid questionId)
        {
            var answers = await _unitOfWork.Answers.GetAllByQuestionIdAsync(questionId);
            if (answers == null || !answers.Any())
            {
                return NotFound();
            }
            var answerResponses = _mapper.Map<IEnumerable<AnswerResponse>>(answers);
            return Ok(answerResponses);
        }

        [HttpPost]
        public async Task<ActionResult<AnswerResponse>> CreateAnswer([FromBody] AnswerRequest answerRequest)
        {
            var answer = _mapper.Map<Answer>(answerRequest);
            _unitOfWork.Answers.Add(answer);
            await _unitOfWork.CompleteAsync();

            var answerResponse = _mapper.Map<AnswerResponse>(answer);
            return CreatedAtAction(nameof(GetAnswer), new { id = answer.Id }, answerResponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnswer(Guid id, [FromBody] AnswerRequest answerRequest)
        {
            var answer = await _unitOfWork.Answers.GetById(id);
            if (answer == null)
            {
                return NotFound();
            }

            _mapper.Map(answerRequest, answer);
            _unitOfWork.Answers.Update(answer);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnswer(Guid id)
        {
            var success = await _unitOfWork.Answers.Delete(id);
            if (!success)
            {
                return NotFound();
            }
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }
    }
}
