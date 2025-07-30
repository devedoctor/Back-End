using Microsoft.AspNetCore.Mvc;
using StudentResultsApp.Models;
using Microsoft.Data.SqlClient;

namespace StudentResultsApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(int setNo, int id)
        {
            var student = GetStudentResult(setNo, id);
            if (student == null)
            {
                ViewBag.Error = "Student not found. Please check your SetNo and ID.";
                return View("Index");
            }
            return View("Results", student);
        }

        private StudentResult? GetStudentResult(int setNo, int id)
        {
            var connectionString = _configuration.GetConnectionString("StudentResultsDb");
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "SELECT * FROM StudentResult WHERE SetNo = @SetNo AND Id = @Id",
                    connection);
                command.Parameters.AddWithValue("@SetNo", setNo);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new StudentResult
                        {
                            SetNo = (int)reader["SetNo"],
                            Id = (int)reader["Id"],
                            Name = reader["Name"].ToString(),
                            Stage = reader["Stage"].ToString(),
                            Grade = (int)reader["Grade"],
                            StudyYear = reader["StudyYear"].ToString(),
                            // Map all subject properties...
                            Subject1Name = reader["Subject1Name"].ToString(),
                            Subject1MaxDegree = (decimal)reader["Subject1MaxDegree"],
                            Subject1minDegree = (decimal)reader["Subject1minDegree"],
                            Subject1StudentDegree = (decimal)reader["Subject1StudentDegree"],
                            Subject1StudentGraduation = reader["Subject1StudentGraduation"].ToString(),
                            // ... Repeat for all subjects


                            // Subject 2
                            Subject2Name = reader["Subject2Name"].ToString(),
                            Subject2MaxDegree = (decimal)reader["Subject2MaxDegree"],
                            Subject2MinDegree = (decimal)reader["Subject2minDegree"],
                            Subject2StudentDegree = (decimal)reader["Subject2StudentDegree"],
                            Subject2StudentGraduation = reader["Subject2StudentGraduation"].ToString(),

                            // Subject 3
                            Subject3Name = reader["Subject3Name"].ToString(),
                            Subject3MaxDegree = (decimal)reader["Subject3MaxDegree"],
                            Subject3MinDegree = (decimal)reader["Subject3minDegree"],
                            Subject3StudentDegree = (decimal)reader["Subject3StudentDegree"],
                            Subject3StudentGraduation = reader["Subject3StudentGraduation"].ToString(),

                            // Subject 4
                            Subject4Name = reader["Subject4Name"].ToString(),
                            Subject4MaxDegree = (decimal)reader["Subject4MaxDegree"],
                            Subject4MinDegree = (decimal)reader["Subject4minDegree"],
                            Subject4StudentDegree = (decimal)reader["Subject4StudentDegree"],
                            Subject4StudentGraduation = reader["Subject4StudentGraduation"].ToString(),

                            // Subject 5
                            Subject5Name = reader["Subject5Name"].ToString(),
                            Subject5MaxDegree = (decimal)reader["Subject5MaxDegree"],
                            Subject5MinDegree = (decimal)reader["Subject5minDegree"],
                            Subject5StudentDegree = (decimal)reader["Subject5StudentDegree"],
                            Subject5StudentGraduation = reader["Subject5StudentGraduation"].ToString(),

                            // Subject 6
                            Subject6Name = reader["Subject6Name"].ToString(),
                            Subject6MaxDegree = (decimal)reader["Subject6MaxDegree"],
                            Subject6MinDegree = (decimal)reader["Subject6minDegree"],
                            Subject6StudentDegree = (decimal)reader["Subject6StudentDegree"],
                            Subject6StudentGraduation = reader["Subject6StudentGraduation"].ToString(),

                            // Subject 7
                            Subject7Name = reader["Subject7Name"].ToString(),
                            Subject7MaxDegree = (decimal)reader["Subject7MaxDegree"],
                            Subject7MinDegree = (decimal)reader["Subject7minDegree"],
                            Subject7StudentDegree = (decimal)reader["Subject7StudentDegree"],
                            Subject7StudentGraduation = reader["Subject7StudentGraduation"].ToString(),

                            // Subject 8
                            Subject8Name = reader["Subject8Name"].ToString(),
                            Subject8MaxDegree = (decimal)reader["Subject8MaxDegree"],
                            Subject8MinDegree = (decimal)reader["Subject8minDegree"],
                            Subject8StudentDegree = (decimal)reader["Subject8StudentDegree"],
                            Subject8StudentGraduation = reader["Subject8StudentGraduation"].ToString(),

                            // Subject 9
                            Subject9Name = reader["Subject9Name"].ToString(),
                            Subject9MaxDegree = (decimal)reader["Subject9MaxDegree"],
                            Subject9MinDegree = (decimal)reader["Subject9minDegree"],
                            Subject9StudentDegree = (decimal)reader["Subject9StudentDegree"],
                            Subject9StudentGraduation = reader["Subject9StudentGraduation"].ToString(),

                            // Subject 10
                            Subject10Name = reader["Subject10Name"].ToString(),
                            Subject10MaxDegree = (decimal)reader["Subject10MaxDegree"],
                            Subject10MinDegree = (decimal)reader["Subject10minDegree"],
                            Subject10StudentDegree = (decimal)reader["Subject10StudentDegree"],
                            Subject10StudentGraduation = reader["Subject10StudentGraduation"].ToString(),

                            TotalMaxDegree = (decimal)reader["TotalMaxDegree"],
                            TotalminDegree = (decimal)reader["TotalminDegree"],
                            TotalStudentDegree = (decimal)reader["TotalStudentDegree"],
                            TotalGraduation = reader["TotalGraduation"].ToString(),
                            TotalPercentage = reader["TotalPercentage"].ToString()
                        };
                    }
                }
            }
            return null;
        }
    }
}