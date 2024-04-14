using System.ComponentModel.DataAnnotations;

namespace voter_application.Models
{
    public class users
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Full Name is required")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email or Mobile Number is required")]
        public string EmailOrMobile { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
