using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestGuru.DAL.Data;
using TestGuru.DAL.Repositories.Interfaces;
using TestGuru.Domain.Entities;

namespace TestGuru.DAL.Repositories
{
    public class QuestionRepository : GenericRepository<Question>
    {
        public QuestionRepository(AppDbContext context, ILogger<QuestionRepository> logger) : base(context, logger)
        {
        }
        public virtual async Task<IEnumerable<Question>> GetQuestionsByCategoryIdAsync(Guid categoryId)
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
                _logger.LogError(e, "[{Repo}] GetQuestionsByCategoryId function error", typeof(QuestionRepository));
                throw;
            }
        }

        public virtual async Task<IEnumerable<Question>> GetQuestionsByTestIdAsync(Guid testId)
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
                _logger.LogError(e, "[{Repo}] GetQuestionsByTestIdAsync function error", typeof(QuestionRepository));
                throw;
            }
        }
    }
}
