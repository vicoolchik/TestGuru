using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestGuruApi.DataService.Data;
using TestGuruApi.DataService.Repositories.Interfaces;
using TestGuruApi.Entities.DbSet;

namespace TestGuruApi.DataService.Repositories
{
    public class TestRepository : GenericRepository<Test>, ITestRepository
    {
        public TestRepository(AppDbContext context, ILogger logger) : base(context, logger)
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
