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
    public class TestCollectionController : BaseController
    {
        public TestCollectionController(IMapper mapper, IMediator mediator) : base(mapper, mediator)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestCollectionResponse>>> GetAllTestCollections()
        {
            var query = new GetAllTestCollectionsQuery();
            var testCollections = await _mediator.Send(query);
            return Ok(testCollections);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TestCollectionResponse>> GetTestCollection(Guid id)
        {
            var query = new GetTestCollectionByIdQuery(id);
            var testCollection = await _mediator.Send(query);
            return testCollection != null ? Ok(testCollection) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<TestCollectionResponse>> CreateTestCollection([FromBody] TestCollectionRequest testCollectionRequest)
        {
            var command = new CreateTestCollectionCommand(testCollectionRequest);
            var testCollectionResponse = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetTestCollection), new { id = testCollectionResponse.Id }, testCollectionResponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTestCollection(Guid id, [FromBody] TestCollectionRequest testCollectionRequest)
        {
            var command = new UpdateTestCollectionCommand(id, testCollectionRequest);
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestCollection(Guid id)
        {
            var command = new DeleteTestCollectionCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
