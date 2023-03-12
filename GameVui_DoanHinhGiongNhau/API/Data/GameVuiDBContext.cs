using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class GameVuiDBContext : DbContext
    {
        public DbSet<Question> questions { get; set; }
        public DbSet<Player> players { get; set; }
        public DbSet<Record> records { get; set; }
        public GameVuiDBContext(DbContextOptions<GameVuiDBContext> options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //add primary key for question
            modelBuilder.Entity<Question>()
                .HasKey(c => c.Id);
            //add primary key for player
            modelBuilder.Entity<Player>()
                .HasKey(c => c.Id);
            //add primary key for record
            modelBuilder.Entity<Record>()
                .HasKey(c => c.Id);
            //add foreign key for record
            modelBuilder.Entity<Record>()
                .HasOne<Player>(c => c.Player)
                .WithMany(g => g.records)
                .HasForeignKey(s => s.PlayerId);
            //add cascade delete for player
            modelBuilder.Entity<Player>()
                .HasMany<Record>(c => c.records)
                .WithOne(g => g.Player)
                .HasForeignKey(c => c.PlayerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
