using Microsoft.EntityFrameworkCore;
using Shared.Data;

namespace Actividad01.Api.Data;

public class StudentRepository
{
    private readonly StudentDb _db;

    public StudentRepository(StudentDb db)
    {
        _db = db;
    }

    public Task<List<Student>> GetAllAsync()
    {
        return _db.Students.ToListAsync();
    }

    public Task<Student?> GetAsync(int id)
    {
        return _db.Students.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async  Task<Student> CreateAsync(Student student)
    {
        student.Id = 0;
       await _db.Students.AddAsync(student);
       await _db.SaveChangesAsync();

       return student;
    }

    public async  Task DeleteAsync(int id)
    {
        var student = await GetAsync(id);
        if (student is null)
            return;
        _db.Students.Remove(student);
        await _db.SaveChangesAsync();
    }

    public Task UpdateAsync(int id, Student student)
    {
        throw new NotImplementedException();
    }
}