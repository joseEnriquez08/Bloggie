using System.ComponentModel.DataAnnotations;

namespace Bloggie.Web.Models.ViewModels
{
    public class Login
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
