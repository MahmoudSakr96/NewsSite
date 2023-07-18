using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Business.Dto
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Please enter user name.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "User Name")]
        [StringLength(30)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(20)]
        public string Password { get; set; }


    }
}
