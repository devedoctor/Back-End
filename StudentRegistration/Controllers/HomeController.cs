using Microsoft.AspNetCore.Mvc;
using StudentRegistration.Models;
using StudentRegistration.Services;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;

namespace StudentRegistration.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StudentService _studentService;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public HomeController(ILogger<HomeController> logger,
                            StudentService studentService,
                            IWebHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _studentService = studentService;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View(new Student());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Student student)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Handle file upload
                    if (student.ProfileImageFile != null && student.ProfileImageFile.Length > 0)
                    {
                        var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");

                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }

                        var uniqueFileName = Guid.NewGuid().ToString() + "_" +
                            Path.GetFileName(student.ProfileImageFile.FileName);
                        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await student.ProfileImageFile.CopyToAsync(fileStream);
                        }

                        student.ProfilePicturePath = "/images/" + uniqueFileName;
                    }
                    else
                    {
                        student.ProfilePicturePath = "/images/default-profile.png";
                    }

                    var createdStudent = await _studentService.CreateStudentAsync(student);
                    return RedirectToAction("Success", new { id = createdStudent.Id });
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error saving student");
                    ModelState.AddModelError("", "An error occurred while saving. Please try again.");
                }
            }
            return View(student);
        }

        public async Task<IActionResult> Success(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        public async Task<IActionResult> Details(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Student student, IFormFile profilePicture)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (profilePicture != null && profilePicture.Length > 0)
                    {
                        var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                        var uniqueFileName = Guid.NewGuid().ToString() + "_" +
                            Path.GetFileName(profilePicture.FileName);
                        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await profilePicture.CopyToAsync(stream);
                        }

                        if (!string.IsNullOrEmpty(student.ProfilePicturePath))
                        {
                            var oldFilePath = Path.Combine(
                                _hostingEnvironment.WebRootPath,
                                student.ProfilePicturePath.TrimStart('/'));

                            if (System.IO.File.Exists(oldFilePath))
                            {
                                System.IO.File.Delete(oldFilePath);
                            }
                        }

                        student.ProfilePicturePath = "/images/" + uniqueFileName;
                    }

                    await _studentService.UpdateStudentAsync(student);
                    return RedirectToAction("List");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error updating student with ID: {Id}", id);
                    ModelState.AddModelError("", "An error occurred while updating. Please try again.");
                }
            }
            return View(student);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var student = await _studentService.GetStudentByIdAsync(id);
                if (student != null)
                {
                    if (!string.IsNullOrEmpty(student.ProfilePicturePath))
                    {
                        var filePath = Path.Combine(
                            _hostingEnvironment.WebRootPath,
                            student.ProfilePicturePath.TrimStart('/'));

                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                    }

                    await _studentService.DeleteStudentAsync(id);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting student with ID: {Id}", id);
                return RedirectToAction("Delete", new { id, error = true });
            }
        }

        public async Task<IActionResult> List()
        {
            try
            {
                var students = await _studentService.GetAllStudentsAsync();
                return View(students);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving student list");
                return View("Error", new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                });
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}