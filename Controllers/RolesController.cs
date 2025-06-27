using CustomIdentityWeb.Data;
using CustomIdentityWeb.Data.Migrations;
using CustomIdentityWeb.Models.IdentityModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace CustomIdentityWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private ApplicationDbContext _dbContext;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<ApplicationRole> _roleManager;
        public RolesController(UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext, RoleManager<ApplicationRole> roleManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: RolesController
        public async Task<IActionResult> Index()
        {
            var roles = await _dbContext.GetAllRolesAsync();
            return View(roles);
        }

        // GET: RolesController/Details/5
        public async Task<IActionResult> Details(string id)
        {
            ApplicationRole role = await _roleManager.FindByIdAsync(id);
            return View(role);
        }

        // GET: RolesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RolesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] ApplicationRole inputRole)
        {
            var role = new ApplicationRole();
            role.Name = inputRole.Name;
            role.NormalizedName = inputRole.Name.ToUpper();

            await _roleManager.CreateAsync(role);

            return RedirectToAction("Index");
        }

        // GET: RolesController/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            return View(role);
        }

        // POST: RolesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name")] ApplicationRole inputRole)
        {
            var role = await _roleManager.FindByIdAsync(id);
            role.Name = inputRole.Name;
            role.NormalizedName = inputRole.Name.ToUpper();

            await _roleManager.UpdateAsync(role);

            return RedirectToAction("Index");
        }

        // GET: RolesController/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            return View(role);
        }

        // POST: RolesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id, IFormCollection collection)
        {
            var role = await _roleManager.FindByIdAsync(id);
           await  _roleManager.DeleteAsync(role);

            return RedirectToAction("Index");
        }
    }
}
