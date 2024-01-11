using TestGuru.UserService.Api.Models;

namespace TestGuru.UserService.Api.Services
{
    public interface IMessageService
    {
        Message GetPublicMessage();
        Message GetProtectedMessage();
        Message GetAdminMessage();
    }

}
