using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Data.Domain.Identity;
using Data.Enums;
using Data.Models.Education;
using Newtonsoft.Json;


namespace Data.Models.Identity
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
        public string RoleName { get; set; }
        public StudentRegisterViewModel Student { get; set; }
        public InstitutionType InstitutionType { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password doesn't match")]
        public string ConfirmPassword { get; set; }

        public List<ApplicationRole> Roles { get; set; }
    }
}
