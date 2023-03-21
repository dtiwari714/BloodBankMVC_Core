using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BloodBankProjectMVCCore.Models
{
    public class DonorModel
    {
        [Key]
        public int DonorID { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(50)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [StringLength(20)]
        public string Phone { get; set; }

        [ForeignKey("BloodType")]
        public int? BloodTypeID { get; set; }
        public BloodTypeModel BloodType { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public UserModel User { get; set; }
    }
}
