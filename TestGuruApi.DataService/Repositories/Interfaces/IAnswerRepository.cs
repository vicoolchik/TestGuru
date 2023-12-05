using TestGuruApi.Entities.DbSet;

namespace TestGuruApi.DataService.Repositories.Interfaces
{
    public interface IAnswerRepository : IGenericRepository<Answer>
    {
        Task<IEnumerable<Answer>> GetAllByQuestionIdAsync(Guid questionId);
    }
}
