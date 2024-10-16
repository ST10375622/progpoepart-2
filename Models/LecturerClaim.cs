using System.ComponentModel.DataAnnotations;

namespace St10375622Part2.Models
{
	public class LecturerClaim
	{
		[Key]
		public int ClaimId { get; set; }

		public int LecturerId { get; set; }
		public string LecturerName { get; set; }

		//Error handling for the hours worked has been set
		[Required(ErrorMessage = "Hours Worked are Required")]
		[Range(1, 1000, ErrorMessage = "Hours Worked must be between 1 and 1000")]
		public int HoursWorked { get; set; }

		//Error handling for the hourly rate has been set
		[Required(ErrorMessage = "Hourly Rate is required")]
		[Range(20, 1000, ErrorMessage = "Hourly Rate must be between 20 and 1000")]
		public int HourlyRate { get; set; }

		//additional notes can not exceed 2000 characters
		[StringLength(2000, MinimumLength = 2, ErrorMessage = "Note must be between 2 and 2000 characters")]
		public string AdditionalNotes { get; set; }

		//the status has been set to a default of "pending"
		public string Status { get; set; } = "Pending";
	}
}
