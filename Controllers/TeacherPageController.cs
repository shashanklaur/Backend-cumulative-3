using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;

public class TeacherPageController : Controller
{
	private readonly SchoolDbContext _context;

	public TeacherPageController(SchoolDbContext context)
	{
		_context = context;
	}

	// GET: Teacher/Edit/{id}
	public IActionResult Edit(int id)
	{
		var teacher = _context.Teachers.Find(id);
		if (teacher == null)
			return NotFound();

		return View(teacher);
	}

	// POST: Teacher/Edit
	[HttpPost]
	public IActionResult Edit(Teacher teacher)
	{
		if (!ModelState.IsValid)
			return View(teacher);

		var existingTeacher = _context.Teachers.Find(teacher.Id);
		if (existingTeacher == null)
			return NotFound();

		existingTeacher.Name = teacher.Name;
		existingTeacher.HireDate = teacher.HireDate;
		existingTeacher.Salary = teacher.Salary;

		_context.SaveChanges();

		return RedirectToAction("Index", "Home");
	}
}

