using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DailyReportApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<DailyReport> DailyReports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define a composite primary key using InvoiceNo and Date
            // This assumes that the combination of InvoiceNo and Date uniquely identifies each row.
            modelBuilder.Entity<DailyReport>().HasKey(dr => new { dr.Statement, dr.Date , dr.InvoiceNo });

            // Ensure the decimal types match your SQL Server column definitions
            modelBuilder.Entity<DailyReport>()
                .Property(dr => dr.Value)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<DailyReport>()
                .Property(dr => dr.Date)
                .HasColumnType("date"); // Explicitly set column type for Date

            // Configure new summary columns
            modelBuilder.Entity<DailyReport>()
                .Property(dr => dr.TotalDepit)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<DailyReport>()
                .Property(dr => dr.TotalCredit)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<DailyReport>()
                .Property(dr => dr.NetDifference)
                .HasColumnType("decimal(18,2)");

            base.OnModelCreating(modelBuilder);
        }
    }
}
