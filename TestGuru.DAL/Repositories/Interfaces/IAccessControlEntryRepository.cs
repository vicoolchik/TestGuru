using TestGuru.Domain.Entities;

namespace TestGuru.DAL.Repositories.Interfaces
{
    public interface IAccessControlEntryRepository : IGenericRepository<AccessControlEntry>
    {
        Task<bool> GrantAccessToUser(Guid entryId, User user);
        Task<bool> RevokeAccessFromUser(Guid entryId, User user);
        Task<bool> GrantAccessToGroup(Guid entryId, Group group);
        Task<bool> RevokeAccessFromGroup(Guid entryId, Group group);
        Task<IEnumerable<User>> GetUsersWithAccess(Guid entryId);
    }
}