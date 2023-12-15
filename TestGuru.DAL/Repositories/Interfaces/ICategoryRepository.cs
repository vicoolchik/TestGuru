using TestGuru.Domain.Entities;

namespace TestGuru.DAL.Repositories.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<IEnumerable<Category>> GetAllByTestIdAsync(Guid testId);
    }
}
