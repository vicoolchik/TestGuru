using Microsoft.Extensions.Logging;
using TestGuruApi.DataService.Data;
using TestGuruApi.DataService.Repositories.Interfaces;
using TestGuruApi.Entities.DbSet;

namespace TestGuruApi.DataService.Repositories
{
    public class SingleChoiceQuestionRepository : GenericRepository<SingleChoiceQuestion>, ISingleChoiceQuestionRepository
    {
        public SingleChoiceQuestionRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }
    }
}
