using CustomIdentityWeb.Data;
using CustomIdentityWeb.Models;
using CustomIdentityWeb.Models.IdentityModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CustomIdentityWeb.Controllers
{
    [Authorize(Roles = "admin")]
    public class UsersController : Controller
    {
        private ApplicationDbContext _dbContext;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<ApplicationRole> _roleManager;
        public UsersController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager) 
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: UserController
        public async Task<IActionResult> Index()
        {
            var users = await _dbContext.GetAllUsersAsync();
            return View(users);
        }

        // GET: UserController/Details/5
        public async Task<IActionResult> Details(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return View(user);
        }


        // GET: UserController/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return View(user);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserName", "Email", "FirstName", "LastName", "Address", "Town")] ApplicationUser inputUser)
        {
            var user = await _userManager.FindByIdAsync(id);
            user.UserName = inputUser.UserName;
            user.Email = inputUser.Email;
            user.FirstName = inputUser.FirstName;
            user.LastName = inputUser.LastName;
            user.Address = inputUser.Address;
            user.Town = inputUser.Town;

            await _userManager.UpdateAsync(user);

            return RedirectToAction("Index");
        }

        // GET: UserController/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return View(user);
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id, IFormCollection collection)
        {
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(user);

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Roles(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var roles = await _userManager.GetRolesAsync(user);

            var userRoleViewModel = new UserRoleViewModel()
            {
                User = user,
                Roles = roles
            };

            await _userManager.AddToRoleAsync(user, "Admin");
            await _userManager.UpdateAsync(user);

            return View(userRoleViewModel);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]

        //public async Task<IActionResult> RemoveRole(string id, string role)
        //{
        //    return View();
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]

        //public async Task<IActionResult> AssignRole(string id, [Bind("RoleName")] AssignRoleViewModel inputViewModel)
        //{
        //    var user = await _userManager.FindByIdAsync(id);

        //    var userHasRole = await _userManager.IsInRoleAsync(user, inputViewModel.RoleName);

        //    if (userHasRole)
        //    {
        //        return RedirectToAction("Index");
        //    }

        //    var isRoleExist = await _userManager.RoleExistsAsync(inputViewModel.RoleName);

        //    if (isRoleExist)
        //    {
        //        await _userManager.AddToRoleAsync(user, inputViewModel.RoleName);

        //    }
        //    else
        //    {
        //        var role = new ApplicationRole(inputViewModel.RoleName);
        //        var result = await _roleManager.CreateAsync(role);

        //        if (result.Succeeded)
        //        {
        //            await _userManager.AddToRoleAsync(user.roleName);
        //        }
        //    }

        //    return RedirectToAction("Index");

        //}


        //public async Task<IActionResult> DeleteUserRole(string id, string role)
        //{
        //    var viewModel = new DeleteUserRoleViewModel();

        //    var user = await _userManager.FindByIdAsync(id);

        //    viewModel.User = user;
        //    viewModel.RoleName = role;

        //    return View(viewModel);
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[ActionName("DeleteUserRole")]

        //public async Task<IActionResult> DeleteUserRoleConfirm([Bind("User", "RoleName")] DeleteUserRoleViewModel viewModel)
        //{
        //    var user = await _userManager.FindByIdAsync(viewModel.User.Id);

        //    await _userManager.RemoveFromRoleAsync(user, viewModel.RoleName);
        //    await _userManager.UpdateAsync(user);

        //    return RedirectToAction("Index");
        //}

    }
}
