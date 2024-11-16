using Microsoft.AspNetCore.Mvc;
using MiniCourse.WebUI.Roles;
using MiniCourse.WebUI.Roles.ViewModels;
using MiniCourse.WebUI.Users;

namespace MiniCourse.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RolesController(IRoleService roleService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var rolesResult = await roleService.GetRolesAsync();
            return View(rolesResult.Data);
        }

        public IActionResult RoleCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RoleCreate(RoleCreateViewModel model)
        {
            var roleCreateResult = await roleService.CreateRoleAsync(model);

            if (roleCreateResult.AnyError)
            {
                foreach (var error in roleCreateResult.Errors!)
                {
                    ModelState.AddModelError(string.Empty, error);
                }

                return View(model);
            }
            return RedirectToAction(nameof(RolesController.Index));
        }

        public async Task<IActionResult> RoleUpdate(string roleId)
        {
            var roleresult = await roleService.GetRoleAsync(roleId);
            return View(roleresult.Data);
        }

        [HttpPost]
        public async Task<IActionResult> RoleUpdate(RoleUpdateViewModel model)
        {

            var updateRoleResult = await roleService.UpdateRoleAsync(model);

            if (updateRoleResult.AnyError)
            {
                foreach (var error in updateRoleResult.Errors!)
                {
                    ModelState.AddModelError(string.Empty, error);
                }

                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RoleDelete(string roleId)
        {
            var deleteRoleResult = await roleService.DeleteRoleAsync(roleId);

            if (deleteRoleResult.AnyError)
            {
                foreach (var error in deleteRoleResult.Errors!)
                {
                    ModelState.AddModelError(string.Empty, error);
                }

                return View();
            }
            return RedirectToAction(nameof(RolesController.Index));
        }
    }
}
