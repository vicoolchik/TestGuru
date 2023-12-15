using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestGuru.DAL.Data;
using TestGuru.DAL.Repositories.Interfaces;
using TestGuru.Domain.Entities;

namespace TestGuru.DAL.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context, ILogger<CategoryRepository> logger) : base(context, logger)
        {
        }
        public async Task<IEnumerable<Category>> GetAllByTestIdAsync(Guid testId)
        {
            try
            {
                var categories = await _dbSet
                    .AsNoTracking()
                    .Include(c => c.Test)
                    .Where(c => c.TestId == testId)
                    .ToListAsync();

                return categories;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "[{Repo}] GetAllByTestId function error", typeof(CategoryRepository));
                throw;
            }
        }


    }
}
