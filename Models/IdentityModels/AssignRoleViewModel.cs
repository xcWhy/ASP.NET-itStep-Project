using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomIdentityWeb.Models.IdentityModels
{
    public class AssignRoleViewModel
    {
        public ApplicationUser User { get; set; }

        public string RoleName { get; set; }
    }
}
