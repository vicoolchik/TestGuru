using TestGuruApi.Entities.DbSet;

namespace TestGuruApi.DataService.Repositories.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<IEnumerable<Category>> GetAllByTestIdAsync(Guid testId);
    }
}
