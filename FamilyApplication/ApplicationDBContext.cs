using FamilyApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyApplication
{
    public class ApplicationDBContext : DbContext
    {
 

        public ApplicationDBContext()
        {
            

        }
        public DbSet<User> Users { get; set; }
        public  DbSet<Category> Categories { get; set; }
        public  DbSet<CalendarEntry> CalendarEntries { get; set; }


        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
           
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
            optionsBuilder.LogTo(Console.WriteLine);
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = Guid.NewGuid(), CategoryName = "Abby" }, new Category { CategoryId = Guid.NewGuid(), CategoryName = "Familie" }, new Category { CategoryId = Guid.NewGuid(), CategoryName = "Sabina" }, new Category { CategoryId = Guid.NewGuid(), CategoryName = "Darius" });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(c => c.CategoryName).IsRequired();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(c => c.UserName).IsRequired();
                entity.Property(u => u.Password).IsRequired();
            });

        }

        

    }
}
