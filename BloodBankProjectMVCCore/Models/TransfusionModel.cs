using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;

namespace BloodBankProjectMVCCore.Models
{
    public class TransfusionModel
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DQ4VN0E;Initial Catalog=BloodBankDb;Integrated Security=True;TrustServerCertificate=True;Encrypt=True;");

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
