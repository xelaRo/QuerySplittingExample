using Microsoft.EntityFrameworkCore;
using QuerySplittingExample.Data.Entities;

namespace QuerySplittingExample.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Author> Author { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> dbContext) : base(dbContext) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var courseData = new[] {
                new Course() { Id = 1, Name = "Data Engineering", DateAdded = DateTime.Now,  AuthorId = 1 },
                new Course() { Id = 2, Name = "C# Programming", DateAdded = DateTime.Now,  AuthorId = 1  },
                new Course() { Id = 3, Name = "Social Engineering", DateAdded = DateTime.Now,  AuthorId = 2 },
                new Course() { Id = 4, Name = "NLP", DateAdded = DateTime.Now,  AuthorId = 3  },
                new Course() { Id = 5, Name = "Marketing", DateAdded = DateTime.Now,  AuthorId = 3  },
                new Course() { Id = 6, Name = "Accounting", DateAdded = DateTime.Now, AuthorId = 4 },
                new Course() { Id = 7, Name = "Data Mining", DateAdded = DateTime.Now, AuthorId = 5  },
                new Course() { Id = 8, Name = "Machine Learning", DateAdded = DateTime.Now, AuthorId = 5  },
                new Course() { Id = 9, Name = "Mobile Development", DateAdded = DateTime.Now, AuthorId = 5 },
            };

            modelBuilder.Entity<Course>().HasData(courseData);

            var authorData = new[] {
                new Author() { Id = 1, FirstName = "Mike", LastName = "Miers", DateOfRegistration = DateTime.Now},
                new Author() { Id = 2, FirstName = "Alex", LastName = "Spax", DateOfRegistration = DateTime.Now},
                new Author() { Id = 3, FirstName = "Bob", LastName = "Marley", DateOfRegistration = DateTime.Now},
                new Author() { Id = 4, FirstName = "Ana", LastName = "Mikela", DateOfRegistration = DateTime.Now},
                new Author() { Id = 5, FirstName = "Maria", LastName = "Janovsky", DateOfRegistration = DateTime.Now},
            };

            modelBuilder.Entity<Author>().HasData(authorData);
        }
    }
}
