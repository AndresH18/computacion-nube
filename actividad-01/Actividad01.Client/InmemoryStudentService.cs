using Shared.Data;
using Shared.Services;

namespace Actividad01.Client;

internal class InmemoryStudentService : IStudentService
{
    public const string SettingsKey = "ApiUrl";

    private readonly List<Student> _students = [];

    public Task CreateAsync(Student student)
    {
        _students.Add(student);
        student.Id = _students.Count;
        return Task.CompletedTask;
    }

    public Task<List<Student>> GetAllAsync()
    {
        return Task.FromResult(_students);
    }

    public Task DeleteAsync(int id)
    {
        var index = _students.FindIndex(s => s.Id == id);
        _students.RemoveAt(index);
        return Task.CompletedTask;
    }
}