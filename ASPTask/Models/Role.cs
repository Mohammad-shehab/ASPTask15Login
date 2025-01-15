using System.ComponentModel.DataAnnotations;

namespace ASPTask.Models
{
    public class Role
    {
        public int RoleId { get; set; }


        [Display(Name ="Department Name")]
        [Required(ErrorMessage ="Enter Department Name")]
        public string RoleName { get; set; }

    }






}
