using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MiniCourse.WebUI.Areas.Admin.Models;

namespace MiniCourse.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RolesController : Controller
    {
        public IActionResult Index()
        {
            //var roles = await _roleManager.Roles.Select(x => new RoleViewModel()
            //{
            //    Id = x.Id,
            //    Name = x.Name!
            //}).ToListAsync();



            //return View(roles);
            return View();
        }

        public IActionResult RoleCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RoleCreate(RoleCreateViewModel request)
        {
            //var result = await _roleManager.CreateAsync(new AppRole() { Name = request.Name });

            //if (!result.Succeeded)
            //{

            //    ModelState.AddModelErrorList(result.Errors);
            //    return View();
            //}


            //TempData["SuccessMessage"] = "Rol oluşturulmuştur.";
            return RedirectToAction(nameof(RolesController.Index));
        }

        public async Task<IActionResult> RoleUpdate(string id)
        {
            //var roleToUpdate = await _roleManager.FindByIdAsync(id);

            //if (roleToUpdate == null)
            //{
            //    throw new Exception("Güncellenecek rol bulunamamıştır.");
            //}


            //return View(new RoleUpdateViewModel() { Id = roleToUpdate.Id, Name = roleToUpdate!.Name! });

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RoleUpdate(RoleUpdateViewModel request)
        {

            //var roleToUpdate = await _roleManager.FindByIdAsync(request.Id);

            //if (roleToUpdate == null)
            //{
            //    throw new Exception("Güncellenecek rol bulunamamıştır.");
            //}
            //roleToUpdate.Name = request.Name;

            //await _roleManager.UpdateAsync(roleToUpdate);


            //ViewData["SuccessMessage"] = "Rol bilgisi güncellenmiştir";

            return View();
        }

        public async Task<IActionResult> RoleDelete(string id)
        {
            //var roleToDelete = await _roleManager.FindByIdAsync(id);

            //if (roleToDelete == null)
            //{
            //    throw new Exception("Silinecek rol bulunamamıştır.");
            //}

            //var result = await _roleManager.DeleteAsync(roleToDelete);

            //if (!result.Succeeded)
            //{
            //    throw new Exception(result.Errors.Select(x => x.Description).First());
            //}

            //TempData["SuccessMessage"] = "Rol silinmiştir";
            return RedirectToAction(nameof(RolesController.Index));
        }
    }
}
