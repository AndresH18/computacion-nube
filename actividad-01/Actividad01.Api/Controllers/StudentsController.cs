using Actividad01.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Shared.Data;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace Actividad01.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly StudentRepository _repository;

    public StudentsController(StudentRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    [ProducesResponseType<Student>(Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    public async Task<ActionResult> Create(Student student)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        student = await _repository.CreateAsync(student);

        return CreatedAtAction(nameof(Create), new { Id = student.Id }, student);
    }

    [HttpGet]
    [ProducesResponseType<IEnumerable<Student>>(Status200OK)]
    public async Task<ActionResult<IEnumerable<Student>>> GetAll()
    {
        var students = await _repository.GetAllAsync();
        return Ok(students);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType<Student>(Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    [ProducesResponseType(Status404NotFound)]
    public async Task<ActionResult<Student?>> Get(int id)
    {
        if (id <= 0)
            return BadRequest();

        var student = await _repository.GetAsync(id);
        if (student is null)
            return NotFound();

        return Ok(student);
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(Status204NoContent)]
    [ProducesResponseType(Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        if (id <= 0)
            return BadRequest();

        await _repository.DeleteAsync(id);
        return NoContent();
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(Status204NoContent)]
    [ProducesResponseType(Status400BadRequest)]
    public async Task<IActionResult> Update(int id, [FromBody] Student student)
    {
        if (id <= 0 || student.Id != id)
            return BadRequest();

        await _repository.UpdateAsync(id, student);
        return NoContent();
    }
}