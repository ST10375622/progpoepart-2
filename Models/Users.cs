using System.ComponentModel.DataAnnotations;

namespace St10375622Part2.Models
{
    public class Users
    {
        [Key]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [StringLength(150)]
        public string username { get; set; }

        [Required]
        [StringLength(255)]
        public string password { get; set; }

    }
}
