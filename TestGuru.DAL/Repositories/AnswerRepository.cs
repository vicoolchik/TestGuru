using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestGuru.DAL.Data;
using TestGuru.DAL.Repositories.Interfaces;
using TestGuru.Domain.Entities;

namespace TestGuru.DAL.Repositories
{
    public class AnswerRepository : GenericRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(AppDbContext context, ILogger<AnswerRepository> logger) : base(context, logger)
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
