﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using MiniCourse.WebUI.Categories;
using MiniCourse.WebUI.Courses;
using MiniCourse.WebUI.Courses.ViewModels;

namespace MiniCourse.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class CoursesController(ICourseService courseService,ICategoryService categoryService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var coursesResult = await courseService.GetCoursesAsync();
            return View(coursesResult.Data);
        }

        public async Task<IActionResult> CourseCreate()
        {
            var categories = await categoryService.GetCategoriesAsync(); 
            ViewBag.Categories = categories.Data;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CourseCreate(CourseCreateViewModel model)
        {

            var courseCreateResult = await courseService.CreateCourseAsync(model);

            if (courseCreateResult.AnyError)
            {
                foreach (var error in courseCreateResult.Errors!)
                {
                    ModelState.AddModelError(string.Empty, error);
                }

                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CourseUpdate(int courseId)
        {
            var courseResult = await courseService.GetCourseAsync(courseId);
            if (courseResult.AnyError)
            {
                return NotFound();
            }
            ViewBag.Categories =  (await categoryService.GetCategoriesAsync()).Data;
            return View(courseResult.Data);
        }


        [HttpPost]
        public async Task<IActionResult> CourseUpdate(CourseUpdateViewModel model)
        {
            var updateCourseResult = await courseService.UpdateCourseAsync(model);

            if (updateCourseResult.AnyError)
            {
                foreach (var error in updateCourseResult.Errors!)
                {
                    ModelState.AddModelError(string.Empty, error);
                }

                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CourseDelete(int courseId)
        {
            var deleteCourseResult = await courseService.DeleteCourseAsync(courseId);

            if (deleteCourseResult.AnyError)
            {
                foreach (var error in deleteCourseResult.Errors!)
                {
                    ModelState.AddModelError(string.Empty, error);
                }

                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
