using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Company.Application.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        [Required(ErrorMessage = "The User is Required")]
        [MaxLength(25, ErrorMessage = "Este campo deve conter entre 3 e 25 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 25 caracteres")]
        [DisplayName("Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "The Password is Required")]
        [MaxLength(8, ErrorMessage = "Este campo deve conter entre 2 e 8 caracteres")]
        [MinLength(2, ErrorMessage = "Este campo deve conter entre 2 e 8 caracteres")]
        [DisplayName("Password")]
        public string Password { get; set; }

        public string Role { get; set; }
    }
}
