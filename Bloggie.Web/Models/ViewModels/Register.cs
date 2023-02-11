using System.ComponentModel.DataAnnotations;

namespace Bloggie.Web.Models.ViewModels
{
    public class Register
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
