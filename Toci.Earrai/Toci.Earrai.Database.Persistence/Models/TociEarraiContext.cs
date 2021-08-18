using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class TociEarraiContext : DbContext
    {
        public TociEarraiContext()
        {
        }

        public TociEarraiContext(DbContextOptions<TociEarraiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=Toci.Earrai;Username=postgres;Password=beatka");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_Poland.1250");

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.Emailconfirmed)
                    .HasColumnName("emailconfirmed")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Login).HasColumnName("login");

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Token).HasColumnName("token");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
