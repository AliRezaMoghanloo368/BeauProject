using BeauProject.Shared.Application.DTOs.Files;
using BeauProject.Shared.Domain.Models;
using BeauProject.Shared.Patterns.ResultPattern;

namespace BeauProject.Presentation.Blazor.Services
{
    public class FilesService
    {
        private readonly HttpClient _httpClient;
        public FilesService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API/Files");
        }

        public async Task<Result<bool>?> UploadAsync(CreateFilesDto createFilesDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Files/upload", createFilesDto);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<Result<bool>>();
                return result;
            }
            return null;
        }

        public async Task<Result<List<Files>>?> LoadAsync(FilesDto filesDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Files/load", filesDto);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<Result<List<Files>>>();
                return result;
            }
            return null;
        }
    }
}
