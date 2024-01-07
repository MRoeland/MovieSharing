
using System.ComponentModel.DataAnnotations;

namespace VideotheekWebApp.Models
{
    public class CreateUserViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "First Name")]
        public string Voornaam { get; set; }

        [Display(Name = "Last Name")]
        public string Achternaam { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Roles")]
        public List<string> Roles { get; set; } // New property for user roles
    }

    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "First Name")]
        public string Voornaam { get; set; }

        [Display(Name = "Last Name")]
        public string Achternaam { get; set; }

        [Display(Name = "Roles")]
        public List<string> Roles { get; set; } // New property for user roles
    }

    public class DeleteUserViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}