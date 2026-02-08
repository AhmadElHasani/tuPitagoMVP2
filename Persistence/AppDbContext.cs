using Microsoft.EntityFrameworkCore;
using Domain;

namespace Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Exercise> Exercises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // enum come stringa
            modelBuilder.Entity<Exercise>()
                .Property(e => e.Type)
                .HasConversion<string>();

            // UUID per Id
            // modelBuilder.Entity<Exercise>()
            //     .Property(e => e.Id)
            //     .HasColumnType("uuid")
            //     .ValueGeneratedOnAdd();

            // Stringhe text
            modelBuilder.Entity<Exercise>()
                .Property(e => e.Title)
                .HasColumnType("text")
                .IsRequired();

            modelBuilder.Entity<Exercise>()
                .Property(e => e.Topic)
                .HasColumnType("text");

            modelBuilder.Entity<Exercise>()
                .Property(e => e.Typology)
                .HasConversion<string>();

            modelBuilder.Entity<Exercise>()
                .Property(e => e.Answer1)
                .HasColumnType("text")
                .IsRequired();

            modelBuilder.Entity<Exercise>()
                .Property(e => e.Answer2)
                .HasColumnType("text")
                .IsRequired();

            modelBuilder.Entity<Exercise>()
                .Property(e => e.Answer3)
                .HasColumnType("text")
                .IsRequired();

            modelBuilder.Entity<Exercise>()
                .Property(e => e.Answer4)
                .HasColumnType("text")
                .IsRequired();
            
            modelBuilder.Entity<Exercise>()
                .Property(e => e.LastUpdate)
                .HasColumnType("timestamp with time zone")
                .IsRequired();
        }
    }
}
