using System.ComponentModel.DataAnnotations;

namespace St10375622Part2.Models
{
	public class Lecturer
	{ 
		[Key]
		public int LecturerId { get; set; }
		public string Name { get; set; }
		public string email { get; set; }
		public string Location { get; set; }
	}
}
