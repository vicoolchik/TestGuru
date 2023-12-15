using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestGuru.DAL.Data;
using TestGuru.DAL.Repositories.Interfaces;
using TestGuru.Domain.Entities;

namespace TestGuru.DAL.Repositories
{
    public class SingleChoiceQuestionRepository : GenericRepository<SingleChoiceQuestion>, ISingleChoiceQuestionRepository
    {
        public SingleChoiceQuestionRepository(AppDbContext context, ILogger<SingleChoiceQuestionRepository> logger) : base(context, logger)
        {
        }

        public async Task<IEnumerable<SingleChoiceQuestion>> GetByCategoryIdAsync(Guid categoryId)
        {
            try
            {
                return await _dbSet
                    .Where(q => q.CategoryId == categoryId)
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "[{Repo}] GetByCategoryIdAsync function error", typeof(SingleChoiceQuestionRepository));
                throw;
            }
        }

        public async Task<IEnumerable<SingleChoiceQuestion>> GetByTestIdAsync(Guid testId)
        {
            try
            {
                return await _dbSet
                    .Where(q => q.TestId == testId)
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "[{Repo}] GetByCategoryIdAsync function error", typeof(SingleChoiceQuestionRepository));
                throw;
            }
        }
    }
}
