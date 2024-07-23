using Shared.Data;

namespace Shared.Services;

public interface IStudentService
{
    public const string SettingsKey = "ApiUrl";

    Task CreateAsync(Student student);
    Task<List<Student>> GetAllAsync();
    Task DeleteAsync(int id);
}