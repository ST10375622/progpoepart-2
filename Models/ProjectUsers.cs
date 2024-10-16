

using System.ComponentModel.DataAnnotations;

namespace St10375622Part2.Models
{
    public class ProjectUsers
    {
        [Key]
        public int userId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [EmailAddress]
        public string? Email { get; set; }


    }
}
