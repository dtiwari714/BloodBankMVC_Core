using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BloodBankProjectMVCCore.Models
{
    public class RecipientModel
    {
        [Key]
        public int RecipientID { get; set; }

        [Required(ErrorMessage = "Please enter the recipient's first name")]
        [StringLength(50, ErrorMessage = "The first name must be no more than 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter the recipient's last name")]
        [StringLength(50, ErrorMessage = "The last name must be no more than 50 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter the recipient's email address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [StringLength(50, ErrorMessage = "The email address must be no more than 50 characters")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter the recipient's phone number")]
        [StringLength(20, ErrorMessage = "The phone number must be no more than 20 characters")]
        public string Phone { get; set; }

        [ForeignKey("BloodType")]
        public int? BloodTypeID { get; set; }
        public BloodTypeModel BloodType { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public UserModel User { get; set; }
    }
}
