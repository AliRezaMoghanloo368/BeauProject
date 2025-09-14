using BeauProject.Identity.Application.DTOs.User;
using BeauProject.Identity.Domain.Models;
using BeauProject.Shared.Patterns.ResultPattern;
using Blazored.LocalStorage;
using System.Net.Http.Json;

namespace BeauProject.UI.App.MAUI.Shared.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public AuthService(IHttpClientFactory httpClientFactory, ILocalStorageService localStorage)
        {
            _httpClient = httpClientFactory.CreateClient("API/Users");
            _localStorage = localStorage;
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            var request = new UserDto { UserName = username, Password = password };
            var response = await _httpClient.PostAsJsonAsync("api/User/login", request);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<Result<string>>();
                if (!string.IsNullOrEmpty(result.Data))
                {
                    await _localStorage.SetItemAsync("authToken", result.Data);
                    return true;
                }
            }
            return false;
        }

        public async Task<Result<GetUserDto>> RegisterAsync(CreateUserDto createUserDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/User/register", createUserDto);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<Result<GetUserDto>>();
                return result;
            }
            return null;
        }

        public async Task LogoutAsync()
        {
            await _localStorage.RemoveItemAsync("authToken");
        }

        public async Task<bool> IsLoggedInAsync()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            return !string.IsNullOrEmpty(token);
        }

        public async Task<GetUserDto> GetUserAsync(string userName)
        {
            var response = await _httpClient.GetFromJsonAsync<GetUserDto>($"api/User/userInfo/{userName}");
            return response;
        }
    }
}
