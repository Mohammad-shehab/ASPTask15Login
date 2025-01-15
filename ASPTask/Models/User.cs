using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASPTask.Models
{
    public class User
    {
        //Each User has attributes like Id, Name, Email, Password, and a RoleId

        [Display(Name = "User ID")]

        public Guid UserId { get; set; }


        [Display(Name = "UserName")]
        [Required(ErrorMessage = "Enter User Name")]
        [MinLength(3, ErrorMessage = "At least Name 3 Char")]
        public string UserName { get; set; }




        [Display(Name = "Password")]
        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }




        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Enter Email")]
        [EmailAddress]
        public string Email { get; set; }






        //join user and Role
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role? Role { get; set; }

    }
}
