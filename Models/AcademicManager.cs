using System.ComponentModel.DataAnnotations;

namespace St10375622Part2.Models
{
	public class AcademicManager
	{
		[Key]
		public int AcademicManagerId { get; set; }

		public string Name { get; set; }

		public string email { get; set; }

		public string Location { get; set; }

	}
}
