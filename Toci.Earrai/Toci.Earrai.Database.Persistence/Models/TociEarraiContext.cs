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
        public virtual DbSet<Worksheetcontentshistory> Worksheetcontentshistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=Toci.Earrai;Username=postgres;Password=root");
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

                entity.Property(e => e.Createdat).HasColumnName("createdat");

                entity.Property(e => e.Filename).HasColumnName("filename");

                entity.Property(e => e.Idoffile).HasColumnName("idoffile");

                entity.Property(e => e.Updatedat).HasColumnName("updatedat");
            });

            modelBuilder.Entity<Worksheet>(entity =>
            {
                entity.ToTable("worksheets");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdat).HasColumnName("createdat");

                entity.Property(e => e.Idworkbook).HasColumnName("idworkbook");

                entity.Property(e => e.Sheetname).HasColumnName("sheetname");

                entity.Property(e => e.Updatedat).HasColumnName("updatedat");

                entity.HasOne(d => d.IdworkbookNavigation)
                    .WithMany(p => p.Worksheets)
                    .HasForeignKey(d => d.Idworkbook)
                    .HasConstraintName("worksheets_idworkbook_fkey");
            });

            modelBuilder.Entity<Worksheetcontent>(entity =>
            {
                entity.ToTable("worksheetcontents");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Columnindex).HasColumnName("columnindex");

                entity.Property(e => e.Createdat).HasColumnName("createdat");

                entity.Property(e => e.Idworksheet).HasColumnName("idworksheet");

                entity.Property(e => e.Rowindex).HasColumnName("rowindex");

                entity.Property(e => e.Updatedat).HasColumnName("updatedat");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.HasOne(d => d.IdworksheetNavigation)
                    .WithMany(p => p.Worksheetcontents)
                    .HasForeignKey(d => d.Idworksheet)
                    .HasConstraintName("worksheetcontents_idworksheet_fkey");
            });

            modelBuilder.Entity<Worksheetcontentshistory>(entity =>
            {
                entity.ToTable("worksheetcontentshistory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Columnindex).HasColumnName("columnindex");

                entity.Property(e => e.Createdat).HasColumnName("createdat");

                entity.Property(e => e.Idworksheet).HasColumnName("idworksheet");

                entity.Property(e => e.Rowindex).HasColumnName("rowindex");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.HasOne(d => d.IdworksheetNavigation)
                    .WithMany(p => p.Worksheetcontentshistories)
                    .HasForeignKey(d => d.Idworksheet)
                    .HasConstraintName("worksheetcontentshistory_idworksheet_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
