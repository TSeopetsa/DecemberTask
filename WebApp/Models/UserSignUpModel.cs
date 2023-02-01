using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class UserSignUpModel
    {
        [Required(ErrorMessage = "Please enter your Email")]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Please enter a valid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a strong password")]
        [Compare("ConfirmPassword", ErrorMessage ="Password does not match")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage ="Please confirm your password")]
        [Display(Name ="Confirm password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }


    }
}
