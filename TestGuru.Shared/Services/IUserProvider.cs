using TestGuru.Domain.Entities;

namespace TestGuru.Shared.Services
{
    public interface IUserProvider
    {
        Task<User> GetUserFromAccessToken(string accessToken);
    }
}
