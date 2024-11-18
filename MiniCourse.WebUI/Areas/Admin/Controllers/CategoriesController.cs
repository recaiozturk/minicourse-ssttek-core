using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniCourse.WebUI.Categories;
using MiniCourse.WebUI.Categories.ViewModels;

namespace MiniCourse.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class CategoriesController(ICategoryService categoryService) : Controller
    {
        // Kategori Listeleme
        public async Task<IActionResult> Index()
        {
            var categoriesResult = await categoryService.GetCategoriesAsync();
            return View(categoriesResult.Data);
        }

        // Kategori Oluşturma - GET
        public IActionResult CategoryCreate()
        {
            return View();
        }

        // Kategori Oluşturma - POST
        [HttpPost]
        public async Task<IActionResult> CategoryCreate(CategoryCreateViewModel model)
        {
            var categoryCreateResult = await categoryService.CreateCategoryAsync(model);

            if (categoryCreateResult.AnyError)
            {
                foreach (var error in categoryCreateResult.Errors!)
                {
                    ModelState.AddModelError(string.Empty, error);
                }

                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }

        // Kategori Güncelleme - GET
        public async Task<IActionResult> CategoryUpdate(int categoryId)
        {
            var categoryResult = await categoryService.GetCategoryAsync(categoryId);
            if (categoryResult.AnyError)
            {
                foreach (var error in categoryResult.Errors!)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
            }

            return View(categoryResult.Data);
        }

        // Kategori Güncelleme - POST
        [HttpPost]
        public async Task<IActionResult> CategoryUpdate(CategoryUpdateViewModel model)
        {
            var updateCategoryResult = await categoryService.UpdateCategoryAsync(model);

            if (updateCategoryResult.AnyError)
            {
                foreach (var error in updateCategoryResult.Errors!)
                {
                    ModelState.AddModelError(string.Empty, error);
                }

                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }

        // Kategori Silme
        public async Task<IActionResult> CategoryDelete(int categoryId)
        {
            var deleteCategoryResult = await categoryService.DeleteCategoryAsync(categoryId);

            if (deleteCategoryResult.AnyError)
            {
                foreach (var error in deleteCategoryResult.Errors!)
                {
                    ModelState.AddModelError(string.Empty, error);
                }

                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
