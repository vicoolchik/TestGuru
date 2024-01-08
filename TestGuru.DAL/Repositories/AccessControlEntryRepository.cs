using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestGuru.DAL.Data;
using TestGuru.DAL.Repositories.Interfaces;
using TestGuru.Domain.Entities;

namespace TestGuru.DAL.Repositories
{
    public class AccessControlEntryRepository : GenericRepository<AccessControlEntry>, IAccessControlEntryRepository
    {
        public AccessControlEntryRepository(AppDbContext context, ILogger<AccessControlEntryRepository> logger)
            : base(context, logger)
        {
        }

        public async Task<bool> GrantAccessToUser(Guid entryId, User user)
        {
            var entry = await _context.AccessControlEntries.Include(ace => ace.UsersWithAccess)
                .FirstOrDefaultAsync(ace => ace.Id == entryId);
            if (entry != null)
            {
                if (!entry.UsersWithAccess.Any(u => u.Id == user.Id))
                {
                    entry.UsersWithAccess.Add(user);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> RevokeAccessFromUser(Guid entryId, User user)
        {
            var entry = await _context.AccessControlEntries.Include(ace => ace.UsersWithAccess)
                .FirstOrDefaultAsync(ace => ace.Id == entryId);
            if (entry != null)
            {
                var userToRemove = entry.UsersWithAccess.FirstOrDefault(u => u.Id == user.Id);
                if (userToRemove != null)
                {
                    entry.UsersWithAccess.Remove(userToRemove);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> GrantAccessToGroup(Guid entryId, Group group)
        {
            var entry = await _context.AccessControlEntries.Include(ace => ace.UsersWithAccess)
                .FirstOrDefaultAsync(ace => ace.Id == entryId);
            if (entry != null)
            {
                var usersToAdd = group.Members.Where(m => !entry.UsersWithAccess.Any(u => u.Id == m.Id)).ToList();
                foreach (var user in usersToAdd)
                {
                    entry.UsersWithAccess.Add(user);
                }
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> RevokeAccessFromGroup(Guid entryId, Group group)
        {
            var entry = await _context.AccessControlEntries.Include(ace => ace.UsersWithAccess)
                .FirstOrDefaultAsync(ace => ace.Id == entryId);
            if (entry != null)
            {
                var usersToRemove = entry.UsersWithAccess.Where(u => group.Members.Any(gm => gm.Id == u.Id)).ToList();
                foreach (var user in usersToRemove)
                {
                    entry.UsersWithAccess.Remove(user);
                }
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<User>> GetUsersWithAccess(Guid entryId)
        {
            var entry = await _context.AccessControlEntries.Include(ace => ace.UsersWithAccess)
                .FirstOrDefaultAsync(ace => ace.Id == entryId);
            return entry?.UsersWithAccess ?? Enumerable.Empty<User>();
        }
    }
}
