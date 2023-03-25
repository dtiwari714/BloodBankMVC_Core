using BloodBankProjectMVCCore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BloodBankProjectMVCCore.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public new DbSet<BloodBankModel> BloodBanks { get; set; }
        public new DbSet<BloodTypeModel> BloodTypes { get; set; }
        public new DbSet<DonorModel> Donors { get; set; }
        public new DbSet<RecipientModel> Recipients { get; set; }
        public new DbSet<StaffModel> Staffs { get; set; }
        public new DbSet<StockModel> Stocks { get; set; }
        public new DbSet<TransfusionModel> Transfusions { get; set; }
        public new DbSet<UserModel> Users { get; set; }
    }
}