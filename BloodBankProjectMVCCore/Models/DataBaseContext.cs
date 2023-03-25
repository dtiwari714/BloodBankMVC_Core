using Microsoft.EntityFrameworkCore;
using BloodBankProjectMVCCore.Models;

namespace BloodBankProjectMVCCore.Models
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) {
        }

        public DbSet<UserModel> User { get; set; }

        public DbSet<BloodBankProjectMVCCore.Models.DonorModel> DonorModel { get; set; } = default!;

        public new DbSet<BloodTypeModel> BloodType { get; set; }
        public new DbSet<BloodBankModel> BloodBank { get; set; }
        public new DbSet<StockModel> Stocks { get; set; }
        public new DbSet<RecipientModel> Recipients { get; set; }
        public DbSet<BloodBankProjectMVCCore.Models.StaffModel> StaffModel { get; set; } = default!;
        //public DbSet<BloodBankProjectMVCCore.Models.BloodBankModel> BloodBankModel { get; set; } = default!;
    }

}
