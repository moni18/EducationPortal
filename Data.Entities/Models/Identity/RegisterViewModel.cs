using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Data.Entities.Domain.Identity;
using Data.Entities.Models.Hospital;

namespace Data.Entities.Models.Identity
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Роль")]
        public string RoleName { get; set; }

        public DoctorRegisterViewModel Doctor { get; set; }
        public PatientRegisterViewModel Patient { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password not match.")]
        public string ConfirmPassword { get; set; }

        public List<ApplicationRole> Roles { get; set; }
    }
}
