using Newtonsoft.Json;
using TestGuru.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using TestGuru.Shared.Models;

namespace TestGuru.Shared.Services
{
    public class UserProvider : IUserProvider
    {
        private readonly HttpClient _httpClient;
        private readonly UserManager<User> _userManager;
        private readonly string _userInfoEndpoint;

        public UserProvider(HttpClient httpClient, UserManager<User> userManager, string userInfoEndpoint)
        {
            _httpClient = httpClient;
            _userManager = userManager;
            _userInfoEndpoint = userInfoEndpoint;
        }

        public async Task<User> GetUserFromAccessToken(string accessToken)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, _userInfoEndpoint);
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var userInfo = JsonConvert.DeserializeObject<UserInfo>(content);
            return await CreateUser(userInfo);
        }

        private async Task<User> CreateUser(UserInfo userInfo)
        {
            var user = await _userManager.FindByEmailAsync(userInfo.Email);

            if (user != null)
            {
                return user;
            }

            user = new User
            {
                UserName = userInfo.Email,
                Email = userInfo.Email,
                FirstName = userInfo.GivenName,
                LastName = userInfo.FamilyName
            };

            var result = await _userManager.CreateAsync(user);

            if (result.Succeeded)
            {
                return user;
            }

            return null;
        }
    }
}
