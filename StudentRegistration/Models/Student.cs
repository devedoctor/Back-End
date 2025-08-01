using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentRegistration.Models
{

    [Index(nameof(StudentId), IsUnique = true)]
    public class Student
    {
        [Key]
        public int Id { get; set; }

        // Panel 1: Login Information
        public string? ProfilePicturePath { get; set; }

        [Required(ErrorMessage = "الاسم الكامل مطلوب")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "National ID is required")]
        public string StudentId { get; set; }

        // Panel 2: Personal Information
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Nationality { get; set; }

        [Required]
        public string Religion { get; set; }

        [EmailAddress]
        public string? ParentEmail { get; set; }

        public string? FatherName { get; set; }
        public string? FatherJob { get; set; }
        public string? FatherCertificate { get; set; }
        public string? FatherTelephone { get; set; }
        public string? FatherId { get; set; }
        public string? MotherName { get; set; }
        public string? MotherJob { get; set; }
        public string? MotherQualification { get; set; }
        public string? MotherTelephone { get; set; }
        public string? MotherNationalId { get; set; }

        // Panel 3: Academic Information
        public string? PreviousSchool { get; set; }

        [Required]
        public string? StudyLanguage { get; set; }

        [Required]
        public string? EducationalStage { get; set; }

        [Required]
        public string? GradeLevel { get; set; }

        public string? Governorate { get; set; }
        public string? SecondLanguage { get; set; }
        public string? FirstSiblingName { get; set; }
        public string? FirstSiblingGrade { get; set; }
        public string? SecondSiblingName { get; set; }
        public string? SecondSiblingGrade { get; set; }
        public string? ThirdSiblingName { get; set; }
        public string? ThirdSiblingGrade { get; set; }
        public string? GuardianName { get; set; }
        public string? AbsenceReason { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        [NotMapped]
        public IFormFile? ProfileImageFile { get; set; }

    }
}
