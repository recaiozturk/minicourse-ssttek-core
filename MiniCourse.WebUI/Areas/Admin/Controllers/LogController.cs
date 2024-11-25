using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniCourse.WebUI.NLogs;

namespace MiniCourse.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class LogController(INLogService nLogService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var logResult = await nLogService.GetLogsAsync();
            return View(logResult.Data);
        }

        public async Task<IActionResult> logDelete(int logId)
        {
            var deleteLogResult = await nLogService.DeleteLogAsync(logId);

            if (deleteLogResult.AnyError)
            {
                foreach (var error in deleteLogResult.Errors!)
                {
                    ModelState.AddModelError(string.Empty, error);
                }

                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
