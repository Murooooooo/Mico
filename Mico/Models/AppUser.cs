using Microsoft.AspNetCore.Identity;

namespace Mico.Models
{
    public class AppUser : IdentityUser
    {
        public  string Name { get; set; }
        public string Surname {  get; set; }    
    }
}
