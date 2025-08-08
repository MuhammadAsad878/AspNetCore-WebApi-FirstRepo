using FirstApiProj.Model;
using Microsoft.EntityFrameworkCore;

namespace FirstApiProj.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasData(
                         new Student
                         {
                             Id = 1,
                             Name = "Muhammad Asad",
                             Section = "MB",
                             Address = "Pakpattan",
                             Gpa = 3.22f,
                             CreatedAt = new DateTime(2025, 8, 1),
                             InActive = null
                         },
                         new Student
                         {
                             Id = 2,
                             Name = "Nadim Jawad",
                             Section = "MA",
                             Address = "Lahore",
                             Gpa = 3.75f,
                             CreatedAt = new DateTime(2025, 8, 2),
                             InActive = null
                         },
                         new Student
                         {
                             Id = 3,
                             Name = "Ali Ahmed",
                             Section = "MB",
                             Address = "Karachi",
                             Gpa = 3.9f,
                             CreatedAt = new DateTime(2025, 8, 3),
                             InActive = null
                         },
                         new Student
                         {
                             Id = 4,
                             Name = "Hassan Raza",
                             Section = "MC",
                             Address = "FortAbbas",
                             Gpa = 3.45f,
                             CreatedAt = new DateTime(2025, 8, 4),
                             InActive = null
                         },
                         new Student
                         {
                             Id = 5,
                             Name = "Ayesha Malik",
                             Section = "MA",
                             Address = "Multan",
                             Gpa = 3.6f,
                             CreatedAt = new DateTime(2025, 8, 5),
                             InActive = null
                         }
            );

        }
    }
}
