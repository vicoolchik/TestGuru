using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestGuru.DAL.Data;
using TestGuru.DAL.Repositories.Interfaces;
using TestGuru.Domain.Entities;

namespace TestGuru.DAL.Repositories
{
    public class GroupRepository : GenericRepository<Group>, IGroupRepository
    {
        public GroupRepository(AppDbContext context, ILogger<GroupRepository> logger)
            : base(context, logger)
        {
        }

        public async Task<bool> AddMember(Guid groupId, User user)
        {
            var group = await _context.Groups.Include(g => g.Members)
                .FirstOrDefaultAsync(g => g.Id == groupId);
            if (group != null && !group.Members.Any(m => m.Id == user.Id))
            {
                group.Members.Add(user);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> RemoveMember(Guid groupId, User user)
        {
            var group = await _context.Groups.Include(g => g.Members)
                .FirstOrDefaultAsync(g => g.Id == groupId);
            if (group != null)
            {
                var memberToRemove = group.Members.FirstOrDefault(m => m.Id == user.Id);
                if (memberToRemove != null)
                {
                    group.Members.Remove(memberToRemove);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }

        public async Task<ICollection<User>> GetMembers(Guid groupId)
        {
            var group = await _context.Groups.Include(g => g.Members)
                .FirstOrDefaultAsync(g => g.Id == groupId);
            return group?.Members.ToList() ?? new List<User>();
        }
    }
}
