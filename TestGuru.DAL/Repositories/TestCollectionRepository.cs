using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestGuru.DAL.Data;
using TestGuru.DAL.Repositories.Interfaces;
using TestGuru.Domain.Entities;

namespace TestGuru.DAL.Repositories
{
    public class TestCollectionRepository : GenericRepository<TestCollection>, ITestCollectionRepository
    {
        public TestCollectionRepository(AppDbContext context, ILogger<TestCollectionRepository> logger) : base(context, logger)
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
