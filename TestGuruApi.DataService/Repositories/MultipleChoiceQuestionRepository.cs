using Microsoft.Extensions.Logging;
using TestGuruApi.DataService.Data;
using TestGuruApi.DataService.Repositories.Interfaces;
using TestGuruApi.Entities.DbSet;

namespace TestGuruApi.DataService.Repositories
{
    public class MultipleChoiceQuestionRepository : GenericRepository<MultipleChoiceQuestion>, IMultipleChoiceQuestionRepository
    {
        public MultipleChoiceQuestionRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }
    }
}
