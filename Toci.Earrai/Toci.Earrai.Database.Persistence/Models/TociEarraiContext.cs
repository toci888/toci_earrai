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
        public virtual DbSet<Userrole> Userroles { get; set; }
        public virtual DbSet<Workbook> Workbooks { get; set; }
        public virtual DbSet<Worksheet> Worksheets { get; set; }
        public virtual DbSet<Worksheetcontent> Worksheetcontents { get; set; }

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
            modelBuilder.HasAnnotation("Relational:Collation", "English_United Kingdom.1252");

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

                entity.Property(e => e.Firstname).HasColumnName("firstname");

                entity.Property(e => e.Idrole)
                    .HasColumnName("idrole")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Lastname).HasColumnName("lastname");

                entity.Property(e => e.Password).HasColumnName("password");

                entity.HasOne(d => d.IdroleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Idrole)
                    .HasConstraintName("users_idrole_fkey");
            });

            modelBuilder.Entity<Userrole>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("userroles");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.Emailconfirmed).HasColumnName("emailconfirmed");

                entity.Property(e => e.Firstname).HasColumnName("firstname");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Lastname).HasColumnName("lastname");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Password).HasColumnName("password");
            });

            modelBuilder.Entity<Workbook>(entity =>
            {
                entity.ToTable("workbooks");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Filename).HasColumnName("filename");
            });

            modelBuilder.Entity<Worksheet>(entity =>
            {
                entity.ToTable("worksheets");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idworkbooks).HasColumnName("idworkbooks");

                entity.Property(e => e.Sheetname).HasColumnName("sheetname");

                entity.HasOne(d => d.IdworkbooksNavigation)
                    .WithMany(p => p.InverseIdworkbooksNavigation)
                    .HasForeignKey(d => d.Idworkbooks)
                    .HasConstraintName("worksheets_idworkbooks_fkey");
            });

            modelBuilder.Entity<Worksheetcontent>(entity =>
            {
                entity.ToTable("worksheetcontents");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Columnname)
                    .HasColumnName("columnname")
                    .HasDefaultValueSql("'noName'::text");

                entity.Property(e => e.Columnnumber).HasColumnName("columnnumber");

                entity.Property(e => e.Idworksheet).HasColumnName("idworksheet");

                entity.Property(e => e.Rownumber).HasColumnName("rownumber");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.HasOne(d => d.IdworksheetNavigation)
                    .WithMany(p => p.Worksheetcontents)
                    .HasForeignKey(d => d.Idworksheet)
                    .HasConstraintName("worksheetcontents_idworksheet_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
