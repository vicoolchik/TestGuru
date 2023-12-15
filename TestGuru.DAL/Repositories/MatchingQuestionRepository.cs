using Microsoft.Extensions.Logging;
using TestGuru.DAL.Data;
using TestGuru.DAL.Repositories.Interfaces;
using TestGuru.Domain.Entities;

namespace TestGuru.DAL.Repositories
{
    public class MatchingQuestionRepository : GenericRepository<MatchingQuestion>, IMatchingQuestionRepository
    {
        public MatchingQuestionRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }
    }
}
