using CompanyApi.Models;
using EmployeeApi.Model;
using Microsoft.EntityFrameworkCore;

namespace CompanyApi.Context
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<EmployeeAddress> EmployeeAddresses { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeProject>().HasKey(Ep => new { Ep.EmpId, Ep.ProjectId });

            modelBuilder.Entity<EmployeeProject>().HasOne(ep => ep.Employee)
                .WithMany(e => e.employeeprojects)
                .HasForeignKey(e => e.EmpId);

            modelBuilder.Entity<EmployeeProject>().HasOne(ep => ep.Project)
                .WithMany(p => p.employeeProjects)
                .HasForeignKey(p => p.ProjectId);

            modelBuilder.Entity<User>(entity =>
            {
                //entity.HasNoKey();
                entity.ToTable("UserInfo");
                entity.Property(e => e.UserName).HasMaxLength(30).IsUnicode(false);
                entity.Property(e => e.Email).HasMaxLength(50).IsUnicode(false);
                //entity.Property(e => e.Password).HasMaxLength(20).IsUnicode(false);
            });

            modelBuilder.Entity<Department>().HasMany(d => d.Employees)
                .WithOne(e => e.Department)
                .HasForeignKey(e => e.DeptId)
                .OnDelete(DeleteBehavior.Restrict);

        }

        internal Task FindByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
