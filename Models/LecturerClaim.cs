using System.ComponentModel.DataAnnotations;

namespace St10375622Part2.Models
{
	public class LecturerClaim
	{
		[Key]
		public int ClaimId { get; set; }

		public int LecturerId { get; set; }
		public string LecturerName { get; set; }

		[Required(ErrorMessage = "Hours Worked are Required")]
		[Range(1, 1000, ErrorMessage = "Hours Worked must be between 1 and 1000")]
		public int HoursWorked { get; set; }
		[Required(ErrorMessage = "Hourly Rate is required")]
		[Range(20, 1000, ErrorMessage = "Hourly Rate must be between 20 and 1000")]
		public int HourlyRate { get; set; }

		[StringLength(2000, MinimumLength = 2, ErrorMessage = "Note must be between 2 and 2000 characters")]
		public string AdditionalNotes { get; set; }
		public string Status { get; set; } = "Pending";
	}
}
