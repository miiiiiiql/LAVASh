using Microsoft.EntityFrameworkCore;

namespace LAVASh.DBmodels
{
    public class DBcontext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Place> Place { get; set; }
        public DbSet<HeadSubordinate>  HeadSubordinates {get; set;}

        public DBcontext(DbContextOptions<DBcontext> options): base (options)
        {
            //Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>().HasOne(t => t.Author).WithMany(u => u.AuthorOfTasks).OnDelete(DeleteBehavior.ClientCascade);
            User admin = new User { Email = "admin@mail.ru", Password = "123456", IsAdmin = true, Id = 1};
            modelBuilder.Entity<User>().HasData(admin);
            base.OnModelCreating(modelBuilder);
        }
    }
}
