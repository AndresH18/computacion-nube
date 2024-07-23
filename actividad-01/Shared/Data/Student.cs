using System.ComponentModel.DataAnnotations;

namespace Shared.Data;

public class Student
{
    public int Id { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Name cannot be empty")] public string Name { get; set; } = string.Empty;
}