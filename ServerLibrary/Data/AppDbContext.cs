

using BaseLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;

namespace ServerLibrary.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>()
                .Property(x => x.Rate).HasColumnType("decimal").HasPrecision(18,2);

            modelBuilder.Entity<Check>()
                .Property(x => x.AmountPaid).HasColumnType("decimal").HasPrecision(18, 2);
            modelBuilder.Entity<Check>()
                .Property(x => x.Balance).HasColumnType("decimal").HasPrecision(18, 2);

            
            modelBuilder.Entity<Bill_Plan>()
                .Property(x => x.Bill_Amount).HasColumnType("decimal").HasPrecision(18, 2);
            modelBuilder.Entity<Bill_Plan>()
                .Property(x => x.Bill_Discount).HasColumnType("decimal").HasPrecision(18, 2);
            modelBuilder.Entity<Bill_Plan>()
                .Property(x => x.Total_Bill).HasColumnType("decimal").HasPrecision(18, 2);
            modelBuilder.Entity<Bill_Plan>()
                .Property(x => x.Total_Amount_Due).HasColumnType("decimal").HasPrecision(18, 2);
            modelBuilder.Entity<Customer_Bill>()
                .Property(x => x.Bill_Amount).HasColumnType("decimal").HasPrecision(18, 2);
            modelBuilder.Entity<Customer_Bill>()
                .Property(x => x.Bill_Discount).HasColumnType("decimal").HasPrecision(18, 2);
            modelBuilder.Entity<Customer_Bill>()
                .Property(x => x.Previous_Balance).HasColumnType("decimal").HasPrecision(18, 2);
            modelBuilder.Entity<Customer_Bill>()
                .Property(x => x.Total_Amount_Due).HasColumnType("decimal").HasPrecision(18, 2);
            modelBuilder.Entity<Customer_Bill>()
                .Property(x => x.Total_Balance).HasColumnType("decimal").HasPrecision(18, 2);
            modelBuilder.Entity<Payment>()
                .Property(x => x.TotalFee).HasColumnType("decimal").HasPrecision(18, 2);
            modelBuilder.Entity<Payment>()
                .Property(x => x.Paid).HasColumnType("decimal").HasPrecision(18, 2);
            modelBuilder.Entity<Payment>()
                .Property(x => x.Balance).HasColumnType("decimal").HasPrecision(18, 2);
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<SystemRole> SystemRoles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<GeneralDepartment> GeneralDepartments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<CompanyInfo> CompanyInfos { get; set; }
        public DbSet<Identification> Identifications { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Bill_Creteria> Bill_Creterias { get; set; }
        public DbSet<Bill_Plan> Bill_Plans { get; set; }
        public DbSet<CheckType> CheckTypes { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Customer_Bill> Customer_Bills { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<ModeOfPayment> ModeOfPayments { get; set; }
        public DbSet<Check> Checks { get; set; }
        public DbSet<SecurityQuestion> SecurityQuestions { get; set; }
        public DbSet<Logs> Logs { get; set; }
        public DbSet<RefreshTokenInfo> RefreshTokenInfos { get; set; }
    }
}
