using Microsoft.AspNetCore.Identity;

namespace VideotheekWebApp.Models
{
    public class Lid : IdentityUser
    {
        public bool Deleted {  get; set; }
        public string? Voornaam { get; set; }
        public string? Achternaam { get; set; }

        public Lid()
        {
            Deleted = false;
        }
    }
}
