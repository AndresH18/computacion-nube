using Microsoft.AspNetCore.Mvc;
using Shared.Data;

namespace Actividad01.Api.Controllers;

[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    [HttpPost]
    public ActionResult Create(Student student)
    {
        return Created();
    }

    [HttpGet]
    public ActionResult<IEnumerable<Student>> GetAll()
    {
        return Ok(new List<Student>
        {
            new() { Name = "Andres" }
        });
    }
}