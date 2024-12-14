using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;

[ApiController]
[Route("api/[controller]")]
public class TeacherAPIController : ControllerBase
{
	private readonly SchoolDbContext _context;

	public TeacherAPIController(SchoolDbContext context)
	{
		_context = context;
	}

	[HttpPut("{id}")]
	public IActionResult UpdateTeacher(int id, [FromBody] Teacher teacher)
	{
		var existingTeacher = _context.Teachers.Find(id);
		if (existingTeacher == null) return NotFound("Teacher not found.");

		if (string.IsNullOrWhiteSpace(teacher.Name)) return BadRequest("Name is required.");
		if (teacher.HireDate > DateTime.Now) return BadRequest("Hire date cannot be in the future.");
		if (teacher.Salary < 0) return BadRequest("Salary must be positive.");

		existingTeacher.Name = teacher.Name;
		existingTeacher.HireDate = teacher.HireDate;
		existingTeacher.Salary = teacher.Salary;

		_context.SaveChanges();

		return Ok(existingTeacher);
	}
}

