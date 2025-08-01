using DailyReportApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DailyReportApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            // Initialize with today's date for convenience
            var model = new LoginViewModel { SelectedDate = DateTime.Today };
            return View(model);
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken] // Important for security to prevent CSRF attacks
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Hardcoded credentials for demonstration purposes
                if (model.Username == "admin" && model.Password == "dya2025")
                {
                    // Store the selected date in TempData to pass it to the next request
                    // TempData is ideal for one-time data transfer between redirects.
                    TempData["SelectedDate"] = model.SelectedDate.ToString("yyyy-MM-dd"); // Format for consistent passing

                    // Redirect to the DailyReport Index action
                    return RedirectToAction("Index", "DailyReport");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid username or password.");
                }
            }
            // If ModelState is not valid or credentials are wrong, return the view with errors
            return View(model);
        }
    }
}