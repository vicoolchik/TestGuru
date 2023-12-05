using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestGuruApi.DataService.Data;
using TestGuruApi.DataService.Repositories.Interfaces;
using TestGuruApi.Entities.DbSet;

namespace TestGuruApi.DataService.Repositories
{
    public class AnswerRepository : GenericRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }
        public async Task<IEnumerable<Answer>> GetAllByQuestionIdAsync(Guid questionId)
        {
            try
            {
                return await _dbSet
                    .Where(a => a.QuestionId == questionId)
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "[{Repo}] GetAllByQuestionId function error", typeof(AnswerRepository));
                throw;
            }
        }
    }
}
