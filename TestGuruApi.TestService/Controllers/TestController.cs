using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestGuruApi.DataService.Repositories.Interfaces;
using TestGuruApi.Entities.DbSet;
using TestGuruApi.Entities.Dto.Requests;
using TestGuruApi.Entities.Dto.Responses;

namespace TestGuruApi.TestService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : BaseController
    {
        public TestController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TestResponse>> GetTest(Guid id)
        {
            var test = await _unitOfWork.Tests.GetById(id);
            if (test == null)
            {
                return NotFound();
            }
            var testDto = _mapper.Map<TestResponse>(test);
            return Ok(testDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestResponse>>> GetAllTests()
        {
            var tests = await _unitOfWork.Tests.All();
            var testDtos = _mapper.Map<IEnumerable<TestResponse>>(tests);
            return Ok(testDtos);
        }

        [HttpGet("collection/{testCollectionId}")]
        public async Task<ActionResult<IEnumerable<TestResponse>>> GetTestsByCollection(Guid testCollectionId)
        {
            var tests = await _unitOfWork.Tests.GetTestsByTestCollectionIdAsync(testCollectionId);
            if (tests == null || !tests.Any())
            {
                return NotFound();
            }
            var testDtos = _mapper.Map<IEnumerable<TestResponse>>(tests);
            return Ok(testDtos);
        }


        [HttpPost]
        public async Task<ActionResult<TestResponse>> CreateTest([FromBody] TestRequest testRequestDto)
        {
            var test = _mapper.Map<Test>(testRequestDto);
            await _unitOfWork.Tests.Add(test);
            await _unitOfWork.CompleteAsync();

            var testDto = _mapper.Map<TestResponse>(test);
            return CreatedAtAction("GetTest", new { id = test.Id }, testDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTest(Guid id, [FromBody] TestRequest testRequestDto)
        {
            var test = await _unitOfWork.Tests.GetById(id);
            if (test == null)
            {
                return NotFound();
            }
            _mapper.Map(testRequestDto, test);
            await _unitOfWork.Tests.Update(test);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTest(Guid id)
        {
            var success = await _unitOfWork.Tests.Delete(id);
            if (!success)
            {
                return NotFound();
            }
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }
    }
}
