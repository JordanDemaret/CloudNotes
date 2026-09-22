using CloudNotes.Entities;
using Microsoft.EntityFrameworkCore;

namespace CloudNotes.Context
{
    
    public class CloudNotesDbContext : DbContext
    {
        public CloudNotesDbContext(DbContextOptions<CloudNotesDbContext> options) : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Note>(n =>
            {
                n.HasKey(no => no.Id);

                n.Property(no => no.Titre)
                 .IsRequired()
                 .HasColumnType("NVARCHAR(150)");

                n.Property(no => no.Titre)
                 .IsRequired()
                 .HasColumnType("NVARCHAR(300)");
            });
        }
    }
}
