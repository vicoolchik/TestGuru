using TestGuru.Domain.Entities;

namespace TestGuru.DAL.Repositories.Interfaces
{
    public interface ITestRepository : IGenericRepository<Test> 
    {
        Task<IEnumerable<Test>> GetTestsByTestCollectionIdAsync(Guid testCollectionId);
    }
}
