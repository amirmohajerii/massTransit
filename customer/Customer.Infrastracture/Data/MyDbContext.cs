using Customer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Customer.Infrastracture.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<BaseCustomer> BaseCustomer { get; set; }
        public DbSet<IndividualCustomer> IndividualCustomer { get; set; }
        public DbSet<LegalCustomer> LegalCustomer { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRole { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure TPT inheritance
            modelBuilder.Entity<BaseCustomer>()
                .ToTable("BaseCustomer");

            modelBuilder.Entity<IndividualCustomer>()
                .ToTable("IndividualCustomer");

            modelBuilder.Entity<LegalCustomer>()
                .ToTable("LegalCustomer");

            modelBuilder.Entity<User>()
                .ToTable("User")
                .HasMany(bc => bc.BaseCustomer) // Configure one-to-many relationship
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<Role>()
                .ToTable("Role");

            modelBuilder.Entity<UserRole>()
                .ToTable("UserRole");

            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            // Ensure the child entities and User use the same ID as the parent
            modelBuilder.Entity<IndividualCustomer>()
                .Property(i => i.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<LegalCustomer>()
                .Property(l => l.Id)
                .ValueGeneratedOnAdd();

            // Set UserRoleId as the primary key
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => ur.UserRoleId);

            // Configure the relationships between User, Role, and UserRole
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRole)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRole)
                .HasForeignKey(ur => ur.RoleId);
        }
    }
}
