using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ReviewZone.Models
{
    public class AccountLoginModel
    {
        public int Login_ID { get; set; }
        [Display(Name = "Username")]
        [Required(ErrorMessage = "The Username Field is Required")]
        public string UserName { get; set; }

        [NotMapped]
        [Display(Name = "Current Password")]
        [DataType(DataType.Password)]    
        [Required(ErrorMessage = "The Current Password Field is Required")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "The Password Field is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [Compare("Password", ErrorMessage = "The New password and Confirmation password do not match.")]
        [Display(Name = "Confirm New Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "The Confirm Password Field is Required")]
        public string ConfirmPassword { get; set; }

        //public HttpContextBase HttpContext { get; }
        public RoleTypeModel RoleType { get; set; }
    }
}
