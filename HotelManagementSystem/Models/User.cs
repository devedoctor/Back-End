using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 4)]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Role")]
        public string Role { get; set; } = "Staff";
    }
}