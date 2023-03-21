using System.ComponentModel.DataAnnotations;

namespace BloodBankProjectMVCCore.Models
{
    public class BloodBankModel
    {
        [Key]
        public int BloodBankID { get; set; }

        [Required(ErrorMessage = "Please enter the blood bank name")]
        [StringLength(50, ErrorMessage = "The name must be no more than 50 characters")]
        public string BloodBankName { get; set; }

        [Required(ErrorMessage = "Please enter the blood bank address")]
        [StringLength(100, ErrorMessage = "The address must be no more than 100 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter the blood bank phone number")]
        [StringLength(20, ErrorMessage = "The phone number must be no more than 20 characters")]
        public string Phone { get; set; } 
    }
}
