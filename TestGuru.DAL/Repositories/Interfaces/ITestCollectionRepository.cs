using TestGuru.Domain.Entities;

namespace TestGuru.DAL.Repositories.Interfaces
{
    public interface ITestCollectionRepository : IGenericRepository<TestCollection>
    {
        Task<IEnumerable<TestCollection>> GetAllWithTestsAsync();
    }
}
