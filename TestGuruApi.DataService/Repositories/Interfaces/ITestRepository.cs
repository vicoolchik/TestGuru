using TestGuruApi.Entities.DbSet;

namespace TestGuruApi.DataService.Repositories.Interfaces
{
    public interface ITestRepository : IGenericRepository<Test> 
    {
        Task<IEnumerable<Test>> GetTestsByTestCollectionIdAsync(Guid testCollectionId);
    }
}
