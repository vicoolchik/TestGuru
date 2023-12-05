using TestGuruApi.Entities.DbSet;

namespace TestGuruApi.DataService.Repositories.Interfaces
{
    public interface IQuestionRepository : IGenericRepository<Question>
    {
        Task<IEnumerable<Question>> GetQuestionsByCategoryIdAsync(Guid categoryId);
        Task<IEnumerable<Question>> GetQuestionsByTestIdAsync(Guid testId);
    }
}
