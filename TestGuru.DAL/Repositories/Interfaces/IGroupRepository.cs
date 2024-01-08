using TestGuru.Domain.Entities;

namespace TestGuru.DAL.Repositories.Interfaces
{
    public interface IGroupRepository : IGenericRepository<Group>
    {
        Task<bool> AddMember(Guid groupId, User user);
        Task<bool> RemoveMember(Guid groupId, User user);
        Task<ICollection<User>> GetMembers(Guid groupId);
    }
}
