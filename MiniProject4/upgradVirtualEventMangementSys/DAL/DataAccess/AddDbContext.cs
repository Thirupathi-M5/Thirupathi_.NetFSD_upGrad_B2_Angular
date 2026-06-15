using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.DataAccess
{
    public class AddDbContext : DbContext //inheriting dbcontext to use EFcore
    {
        public AddDbContext(DbContextOptions<AddDbContext> options)
            : base(options)
        {
        }

        // Tables ef
        public DbSet<UserInfo> Users { get; set; }
        public DbSet<EventDetails> Events { get; set; }
        public DbSet<SpeakerDetails> Speakers { get; set; }
        public DbSet<SessionInfo> Sessions { get; set; }
        public DbSet<ParticipantEventDetails> ParticipantEventDetails { get; set; }

        // Optional 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EventDetails>()
                .HasKey(e => e.EventId);
        }
    }
}