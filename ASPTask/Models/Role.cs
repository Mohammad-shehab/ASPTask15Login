using System.ComponentModel.DataAnnotations;

namespace ASPTask.Models
{
    public class Role
    {


        [Display(Name = "Role ID")]
        public int RoleId { get; set; }


        [Display(Name =" Role")]
        [Required(ErrorMessage ="Enter Role Name")]
        public string RoleName { get; set; }

    }






}
