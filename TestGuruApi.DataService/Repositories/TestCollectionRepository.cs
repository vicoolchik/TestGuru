using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestGuruApi.DataService.Data;
using TestGuruApi.DataService.Repositories.Interfaces;
using TestGuruApi.Entities.DbSet;

namespace TestGuruApi.DataService.Repositories
{
    public class TestCollectionRepository : GenericRepository<TestCollection>, ITestCollectionRepository
    {
        public TestCollectionRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<IEnumerable<TestCollection>> GetAllWithTestsAsync()
        {
            try
            {
                return await _dbSet.Include(tc => tc.Tests).AsNoTracking().ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "[{Repo}] GetAllWithTestsAsync function error", typeof(TestCollectionRepository));
                throw;
            }
        }
    }
}
