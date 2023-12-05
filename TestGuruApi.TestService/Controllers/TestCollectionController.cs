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
    public class TestCollectionController : BaseController
    {
        public TestCollectionController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestCollectionResponse>>> GetAllTestCollections()
        {
            var testCollections = await _unitOfWork.TestCollections.All();
            var testCollectionDtos = _mapper.Map<IEnumerable<TestCollectionResponse>>(testCollections);
            return Ok(testCollectionDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TestCollectionResponse>> GetTestCollection(Guid id)
        {
            var testCollection = await _unitOfWork.TestCollections.GetById(id);
            if (testCollection == null)
            {
                return NotFound();
            }
            var testCollectionDto = _mapper.Map<TestCollectionResponse>(testCollection);
            return Ok(testCollectionDto);
        }

        [HttpPost]
        public async Task<ActionResult<TestCollectionResponse>> CreateTestCollection([FromBody] TestCollectionRequest testCollectionRequest)
        {
            var testCollection = _mapper.Map<TestCollection>(testCollectionRequest);
            await _unitOfWork.TestCollections.Add(testCollection);
            await _unitOfWork.CompleteAsync();

            var testCollectionDto = _mapper.Map<TestCollectionResponse>(testCollection);
            return CreatedAtAction(nameof(GetTestCollection), new { id = testCollection.Id }, testCollectionDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTestCollection(Guid id, [FromBody] TestCollectionRequest testCollectionRequest)
        {
            var testCollection = await _unitOfWork.TestCollections.GetById(id);
            if (testCollection == null)
            {
                return NotFound();
            }

            _mapper.Map(testCollectionRequest, testCollection);
            await _unitOfWork.TestCollections.Update(testCollection);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestCollection(Guid id)
        {
            var success = await _unitOfWork.TestCollections.Delete(id);
            if (!success)
            {
                return NotFound();
            }
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }
    }
}
