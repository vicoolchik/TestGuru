using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestGuru.DAL.Data;
using TestGuru.DAL.Repositories.Interfaces;
using TestGuru.Domain.Entities;

namespace TestGuru.DAL.Repositories
{
    public class TestRepository : GenericRepository<Test>, ITestRepository
    {
        public TestRepository(AppDbContext context, ILogger<TestRepository> logger) : base(context, logger)
        {
        }
        public async Task<IEnumerable<Test>> GetTestsByTestCollectionIdAsync(Guid testCollectionId)
        {
            try
            {
                return await _dbSet
                .Where(test => test.TestCollectionId == testCollectionId)
                .AsNoTracking()
                .ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "[{Repo}] GetTestsByTestCollectionIdAsync function error", typeof(TestRepository));
                throw;
            }
        }
    }
}
