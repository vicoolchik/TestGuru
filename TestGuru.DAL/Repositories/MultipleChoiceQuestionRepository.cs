using Microsoft.Extensions.Logging;
using TestGuru.DAL.Data;
using TestGuru.DAL.Repositories.Interfaces;
using TestGuru.Domain.Entities;

namespace TestGuru.DAL.Repositories
{
    public class MultipleChoiceQuestionRepository : GenericRepository<MultipleChoiceQuestion>, IMultipleChoiceQuestionRepository
    {
        public MultipleChoiceQuestionRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }
    }
}
