using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestGuru.Shared.Models;
using TestGuru.Shared.Services;
using TestGuru.UserService.Api.Models;
using TestGuru.UserService.Api.Services;

namespace TestGuru.UserService.Api.Controllers
{
    [ApiController]
    [Route("api/messages")]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly HttpClient _httpClient;
        private readonly IUserProvider _userProvider;

        public MessagesController(IMessageService messageService, HttpClient httpClient, IUserProvider userProvider)
        {
            _messageService = messageService;
            _httpClient = httpClient;
            _userProvider = userProvider;
        }

        [HttpGet("public")]
        public ActionResult<Message> GetPublicMessage()
        {
            return _messageService.GetPublicMessage();
        }
        [HttpGet("protected")]
        [Authorize]
        public async Task<IActionResult> GetProtectedMessage()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            if (string.IsNullOrEmpty(accessToken))
            {
                return Unauthorized("Access Token is required");
            }

            var user = await _userProvider.GetUserFromAccessToken(accessToken);

            if (user == null)
            {
                return NotFound("User not found");
            }

            return Ok(user);
        }
        //[HttpGet("protected")]
        //[Authorize]
        //public async Task<IActionResult> GetProtectedMessage()
        //{
        //    var accessToken = await HttpContext.GetTokenAsync("access_token");

        //    var request = new HttpRequestMessage(HttpMethod.Get, "https://dev-testguru.eu.auth0.com/userinfo");
        //    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

        //    var response = await _httpClient.SendAsync(request);

        //    if (!response.IsSuccessStatusCode)
        //    {
        //        return BadRequest("Не вдалося отримати дані користувача.");
        //    }

        //    var content = await response.Content.ReadAsStringAsync();
        //    var userInfo = JsonConvert.DeserializeObject<UserInfo>(content);

        //    return Ok(userInfo);
        //}

        [HttpGet("admin")]
        [Authorize]
        public ActionResult<Message> GetAdminMessage()
        {
            return _messageService.GetAdminMessage();
        }
    }

}