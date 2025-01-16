using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ASPTask.Models.ViewModels
{
    public class RegisterViewModel
    {
      


        [Display(Name = "UserName")]
        [Required(ErrorMessage = "Enter User Name")]
        [MinLength(3, ErrorMessage = "At least Name 3 Char")]
        public string UserName { get; set; }




        [Display(Name = "Password")]
        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }




        [Required(ErrorMessage = "Enter Confirm Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password ")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match")]
        public string ConfirmPassword { get; set; }




        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Enter Email")]
        [EmailAddress]
        public string Email { get; set; }



        [Required(ErrorMessage ="Enter Confirm Email")]
        [EmailAddress]
        [Display(Name ="Confirm Email Address")]
        [Compare("Email",ErrorMessage ="Email and Confirm Email do not match")]
        public string ConfirmEmail { get; set; }






        //join user and Role
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role? Role { get; set; }
    }
}
