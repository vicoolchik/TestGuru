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
    public class TestController : BaseController
    {
        public TestController(IMapper mapper, IMediator mediator) : base(mapper, mediator)
        {
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TestResponse>> GetTest(Guid id)
        {
            var query = new GetTestByIdQuery(id);
            var testResponse = await _mediator.Send(query);
            return testResponse != null ? Ok(testResponse) : NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestResponse>>> GetAllTests()
        {
            var query = new GetAllTestsQuery();
            var testResponses = await _mediator.Send(query);
            return Ok(testResponses);
        }

        [HttpGet("collection/{testCollectionId}")]
        public async Task<ActionResult<IEnumerable<TestResponse>>> GetTestsByCollection(Guid testCollectionId)
        {
            var query = new GetTestsByTestCollectionIdQuery(testCollectionId);
            var testResponses = await _mediator.Send(query);
            return testResponses.Any() ? Ok(testResponses) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<TestResponse>> CreateTest([FromBody] TestRequest testRequest)
        {
            var command = new CreateTestCommand(testRequest);
            var testResponse = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetTest), new { id = testResponse.Id }, testResponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTest(Guid id, [FromBody] TestRequest testRequest)
        {
            var command = new UpdateTestCommand(id, testRequest);
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTest(Guid id)
        {
            var command = new DeleteTestCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
