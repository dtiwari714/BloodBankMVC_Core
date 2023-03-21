using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BloodBankProjectMVCCore.Models
{
    public class StockModel
    {
        [Key]
        public int StockID { get; set; }

        public int? BloodTypeID { get; set; }

        public int? BloodBankID { get; set; }

        [Required]
        public int Quantity { get; set; }

        [ForeignKey("BloodTypeID")]
        public virtual BloodTypeModel BloodType { get; set; }

        [ForeignKey("BloodBankID")]
        public virtual BloodBankModel BloodBank { get; set; }
    }
}
