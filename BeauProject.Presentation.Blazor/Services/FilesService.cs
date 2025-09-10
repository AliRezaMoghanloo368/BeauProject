using BeauProject.Identity.Application.DTOs.User;
using BeauProject.Identity.Domain.Models;
using BeauProject.Shared.Application.DTOs.Files;
using BeauProject.Shared.Patterns.ResultPattern;
using Blazored.LocalStorage;

namespace BeauProject.Presentation.Blazor.Services
{
    public class FilesService
    {
        private readonly HttpClient _httpClient;
        public FilesService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API/Files");
        }

        public async Task<Result<bool>> UploadAsync(CreateFilesDto createFilesDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Files/upload", createFilesDto);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<Result<bool>>();
                return result;
            }
            return null;
        }
    }
}
