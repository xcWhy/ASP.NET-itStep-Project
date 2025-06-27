using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace CustomIdentityWeb.Models.IdentityModels
{
    public class UserRoleViewModel
    {
        public ApplicationUser User { get; set; }

        public IEnumerable<string> Roles { get; set; }
    }
}
