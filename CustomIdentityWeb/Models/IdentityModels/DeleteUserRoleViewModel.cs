using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomIdentityWeb.Models.IdentityModels
{
    public class DeleteUserRoleViewModel : Controller
    {
        // GET: DeleteUserRoleViewModel
        public ActionResult Index()
        {
            return View();
        }

        // GET: DeleteUserRoleViewModel/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DeleteUserRoleViewModel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeleteUserRoleViewModel/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DeleteUserRoleViewModel/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DeleteUserRoleViewModel/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DeleteUserRoleViewModel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DeleteUserRoleViewModel/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
