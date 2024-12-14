using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Models
{
	public class Teacher
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Name is required")]
		public string Name { get; set; }

		[Required]
		[DataType(DataType.Date)]
		public DateTime HireDate { get; set; }

		[Range(0, double.MaxValue, ErrorMessage = "Salary must be positive")]
		public decimal Salary { get; set; }
	}
}

