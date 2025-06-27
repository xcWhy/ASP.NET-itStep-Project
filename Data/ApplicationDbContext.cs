using CustomIdentityWeb.Models.IdentityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CustomIdentityWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public async Task<List<ApplicationUser>> GetAllUsersAsync()
        {
            return await this.Users.ToListAsync();
        }

        public async Task<List<ApplicationRole>> GetAllRolesAsync()
        {
            return await this.Roles.ToListAsync();
        }
    }
}
