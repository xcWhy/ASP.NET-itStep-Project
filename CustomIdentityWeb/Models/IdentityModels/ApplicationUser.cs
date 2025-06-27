using Microsoft.AspNetCore.Identity;

namespace CustomIdentityWeb.Models.IdentityModels
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }      
        public string Address { get; set; } 
        public string Town { get; set; }  
        
        public ApplicationUser() : base()
        {

        }
    }
}
