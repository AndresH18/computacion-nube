using System.Net.Http.Json;
using Shared.Data;
using Shared.Services;

namespace Actividad01.Client;

public class StudentService : IStudentService
{
    public const string ServiceKey = "Services:Student";

    private readonly HttpClient _httpClient;
    private readonly ILogger<StudentService> _logger;

    public StudentService(HttpClient httpClient, ILogger<StudentService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public Task CreateAsync(Student student)
    {
        return _httpClient.PostAsJsonAsync("api/Students", student);
    }

    public async Task<List<Student>> GetAllAsync()
    {
        _logger.LogInformation($"{nameof(GetAllAsync)}---{_httpClient.BaseAddress}");
        var response = await _httpClient.GetAsync("api/Students");
        return await response.Content.ReadFromJsonAsync<List<Student>>() ?? [];
        // return await _client.GetFromJsonAsync<List<Student>>("students") ?? [];
    }

    public Task DeleteAsync(int id)
    {
        return _httpClient.DeleteAsync($"api/Students/{id}");
    }
}