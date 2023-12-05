using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestGuruApi.DataService.Data;
using TestGuruApi.DataService.Repositories.Interfaces;
using TestGuruApi.Entities.DbSet;

namespace TestGuruApi.DataService.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }
        public async Task<IEnumerable<Category>> GetAllByTestIdAsync(Guid testId)
        {
            try
            {
                return await _dbSet
                    .AsNoTracking()
                    .Include(c => c.Test)
                    .Include(c => c.Questions)
                    .Where(c => c.TestId == testId)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "[{Repo}] GetAllByTestId function error", typeof(CategoryRepository));
                throw;
            }
        }
    }
}
