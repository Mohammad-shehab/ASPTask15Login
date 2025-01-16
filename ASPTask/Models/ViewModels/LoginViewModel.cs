using System.ComponentModel.DataAnnotations;

namespace ASPTask.Models.ViewModels
{
    public class LoginViewModel
    {

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }




        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Enter Email")]
        [EmailAddress]
        public string Email { get; set; }

    }
}
