using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BloodBankProjectMVCCore.Models
{
    public class StaffModel
    {
        [Key]
        public int StaffID { get; set; }

        [Required(ErrorMessage = "Please enter the first name.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The first name must be between 2 and 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter the last name.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The last name must be between 2 and 50 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter the email.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [StringLength(50, ErrorMessage = "The email address cannot exceed 50 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter the phone number.")]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Please enter a valid phone number in the format XXX-XXX-XXXX.")]
        public string Phone { get; set; }

        [ForeignKey("BloodBank")]
        public int? BloodBankID { get; set; }
        public BloodBankModel BloodBank { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public UserModel User { get; set; }
    }
}
