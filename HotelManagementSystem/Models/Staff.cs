using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class Staff
    {
        public int StaffId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Display(Name = "Hire Date")]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; } = DateTime.Now;

        public decimal Salary { get; set; }
    }
}