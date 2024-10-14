using System.ComponentModel.DataAnnotations;

namespace St10375622Part2.Models
{
	public class User
	{
			[Key]
			public int UserId { get; set; }

			public string Name { get; set; }

			public string email { get; set; }

			public string Address { get; set; }

			public string Company { get; set; }

			public string Username { get; set; }

			public string Password { get; set; }
	}
}
