using Microsoft.EntityFrameworkCore;
using Mvc_Day__4.Models;

namespace Mvc_Day__4.Context
{
    public class MyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=./;Database=MVC_D04;Trusted_Connection=True;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var departments = new List<Department>()
            {
                new Department {  DeptId = 1 , DeptName = "SD" },
                new Department {  DeptId = 2 , DeptName = "UI" },
                new Department {  DeptId = 3 , DeptName = "Mob" },
                new Department {  DeptId = 4 , DeptName = "Network" },
            };

            var student = new List<Student>()
            {
                    new Student { Id = 1, Name = "Ahmed Ali", Age = 25, Salary = 5000.00m, Address = "Cairo", Email = "ahmed.ali@example.com", Password = "pass1234", DepartmentId = 1 },
                    new Student { Id = 2, Name = "Mona Said", Age = 30, Salary = 7000.00m, Address = "Giza", Email = "mona.said@example.com", Password = "mona456", DepartmentId = 2 },
                    new Student { Id = 3, Name = "Youssef Gamal", Age = 28, Salary = 6200.00m, Address = "Alexandria", Email = "youssef.g@example.com", Password = "you12345", DepartmentId = 3 },
                    new Student { Id = 4, Name = "Sara Fathy", Age = 22, Salary = 4500.00m, Address = "Mansoura", Email = "sara.fathy@example.com", Password = "sara987", DepartmentId = 1 },
                    new Student { Id = 5, Name = "Khaled Nour", Age = 35, Salary = 9500.00m, Address = "Tanta", Email = "khaled.n@example.com", Password = "khaledpw", DepartmentId = 2 },
                    new Student { Id = 6, Name = "Nour Hassan", Age = 27, Salary = 7100.00m, Address = "Zagazig", Email = "nour.hassan@example.com", Password = "nourpass", DepartmentId = 3 },
                    new Student { Id = 7, Name = "Omar Adel", Age = 29, Salary = 8000.00m, Address = "Ismailia", Email = "omar.adel@example.com", Password = "omar123", DepartmentId = 1 },
                    new Student { Id = 8, Name = "Laila Samir", Age = 32, Salary = 8800.00m, Address = "Aswan", Email = "laila.samir@example.com", Password = "laila321", DepartmentId = 2 },
                    new Student { Id = 9, Name = "Hassan Omar", Age = 26, Salary = 5700.00m, Address = "Fayoum", Email = "hassan.omar@example.com", Password = "hassanpw", DepartmentId = 3 },
                    new Student { Id = 10, Name = "Dina Nabil", Age = 24, Salary = 5200.00m, Address = "Luxor", Email = "dina.nabil@example.com", Password = "dina444", DepartmentId = 4 }
            };

            modelBuilder
                .Entity<Department>()
                .HasData(departments);

            modelBuilder
                .Entity< Student>()
                .HasData(student);

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Department> Departments { get; set; }

    }
}
