using System.ComponentModel.DataAnnotations;

namespace St10375622Part2.Models
{
	public class ProgrammeCoordinator
	{

		[Key]
		public int ProgrammeCoordinatorId { get; set; }

		public string Name { get; set; }

		public string email { get; set; }

		public string Location { get; set; }

	}
}
