using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace BloodBankProjectMVCCore.Models
{
    public class TransfusionModel
    {
        [Key]
        public int TransfusionID { get; set; }

        public int? DonorID { get; set; }

        public int? RecipientID { get; set; }

        public int? StaffID { get; set; }

        [Required]
        public DateTime TransfusionDate { get; set; }

        [ForeignKey("DonorID")]
        public virtual DonorModel Donor { get; set; }

        [ForeignKey("RecipientID")]
        public virtual RecipientModel Recipient { get; set; }

        [ForeignKey("StaffID")]
        public virtual StaffModel Staff { get; set; }
    }
}
