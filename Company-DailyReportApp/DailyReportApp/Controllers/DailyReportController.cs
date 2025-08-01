using DailyReportApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Required for Entity Framework Core methods like ToListAsync, Where
using System;
using System.Collections.Generic;
using System.Linq; // Required for LINQ queries
using System.Threading.Tasks; // Required for async operations

namespace DailyReportApp.Controllers
{
    public class DailyReportController : Controller
    {
        private readonly ApplicationDbContext _context; // Inject DbContext

        // Constructor to inject ApplicationDbContext
        public DailyReportController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /DailyReport/Index
        [HttpGet]
        public async Task<IActionResult> Index() // Make action asynchronous
        {
            // Retrieve the selected date from TempData
            if (TempData["SelectedDate"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            DateTime selectedDate;
            if (!DateTime.TryParse(TempData["SelectedDate"].ToString(), out selectedDate))
            {
                // Handle parsing error, maybe redirect to login or show an error message
                return RedirectToAction("Login", "Account");
            }

            var viewModel = new DailyReportListViewModel
            {
                SelectedDate = selectedDate // Set the selected date in the ViewModel
            };

            try
            {
                // Use Entity Framework Core to query the database
                // .Date is used to compare only the date part, ignoring time
                var reports = await _context.DailyReports
                                             .Where(dr => dr.Date.Date == selectedDate.Date)
                                             .OrderBy(dr => dr.CustCode)
                                             .ToListAsync(); // Execute the query asynchronously

                viewModel.DailyReports = reports;

                // Extract summary data from the first row if available
                // As per your request, assuming these columns exist in DailyReport table
                // and their values are consistent across all rows for a given date,
                // we take them from the first available report.
                var firstReport = reports.FirstOrDefault();
                if (firstReport != null)
                {
                    viewModel.TotalDepit = firstReport.TotalDepit;
                    viewModel.TotalCredit = firstReport.TotalCredit;
                    viewModel.NetDifference = firstReport.NetDifference;
                }
            }
            catch (Exception ex)
            {
                // Log the exception (in a real app, use a logging framework)
                Console.WriteLine($"Database Error: {ex.Message}");
                ModelState.AddModelError(string.Empty, "An error occurred while retrieving data from the database. Please try again later.");
                // Optionally, you could redirect to an error page or show a more user-friendly message
            }

            // Pass the populated ViewModel to the view
            return View(viewModel);
        }
    }
}
