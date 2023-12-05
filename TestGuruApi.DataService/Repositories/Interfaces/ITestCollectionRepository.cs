using TestGuruApi.Entities.DbSet;

namespace TestGuruApi.DataService.Repositories.Interfaces
{
    public interface ITestCollectionRepository : IGenericRepository<TestCollection>
    {
        Task<IEnumerable<TestCollection>> GetAllWithTestsAsync();
    }
}
