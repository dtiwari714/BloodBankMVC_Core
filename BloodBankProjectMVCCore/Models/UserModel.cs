using System.ComponentModel.DataAnnotations;

namespace BloodBankProjectMVCCore.Models
{
    public class UserModel
    {
        [Key]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(256)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(256)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
