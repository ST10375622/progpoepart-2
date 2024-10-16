using Microsoft.AspNetCore.Identity;

namespace St10375622Part2.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string FirstName { get; set; }

		public string LastName { get; set;  }

	}
}
