using Microsoft.AspNetCore.Mvc;
using MiniCourse.WebUI.Categories;
using MiniCourse.WebUI.Courses;

namespace MiniCourse.WebUI.ViewComponents
{
    public class CatDropDownViewComponent(ICategoryService categoryService): ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await categoryService.GetCategoriesAsync();

            return View(categories.Data);
        }
    }
}
