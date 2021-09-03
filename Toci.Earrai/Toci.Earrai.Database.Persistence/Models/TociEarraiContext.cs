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

        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Areaquantity> Areaquantities { get; set; }
        public virtual DbSet<Areasquantity> Areasquantities { get; set; }
        public virtual DbSet<Codesdimension> Codesdimensions { get; set; }
        public virtual DbSet<Quoteandmetric> Quoteandmetrics { get; set; }
        public virtual DbSet<Quoteandprice> Quoteandprices { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Userrole> Userroles { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<Workbook> Workbooks { get; set; }
        public virtual DbSet<Worksheet> Worksheets { get; set; }
        public virtual DbSet<Worksheetcontent> Worksheetcontents { get; set; }
        public virtual DbSet<Worksheetcontentshistory> Worksheetcontentshistories { get; set; }

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

            modelBuilder.Entity<Area>(entity =>
            {
                entity.ToTable("areas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Areaquantity>(entity =>
            {
                entity.ToTable("areaquantity");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdat)
                    .HasColumnName("createdat")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Idarea).HasColumnName("idarea");

                entity.Property(e => e.Idcodesdimensions).HasColumnName("idcodesdimensions");

                entity.Property(e => e.Iduser).HasColumnName("iduser");

                entity.Property(e => e.Idworksheet).HasColumnName("idworksheet");

                entity.Property(e => e.Lengthdimensions).HasColumnName("lengthdimensions");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Rowindex).HasColumnName("rowindex");

                entity.Property(e => e.Updatedat)
                    .HasColumnName("updatedat")
                    .HasDefaultValueSql("now()");

                entity.HasOne(d => d.IdareaNavigation)
                    .WithMany(p => p.Areaquantities)
                    .HasForeignKey(d => d.Idarea)
                    .HasConstraintName("areaquantity_idarea_fkey");

                entity.HasOne(d => d.IdcodesdimensionsNavigation)
                    .WithMany(p => p.Areaquantities)
                    .HasForeignKey(d => d.Idcodesdimensions)
                    .HasConstraintName("areaquantity_idcodesdimensions_fkey");

                entity.HasOne(d => d.IduserNavigation)
                    .WithMany(p => p.Areaquantities)
                    .HasForeignKey(d => d.Iduser)
                    .HasConstraintName("areaquantity_iduser_fkey");

                entity.HasOne(d => d.IdworksheetNavigation)
                    .WithMany(p => p.Areaquantities)
                    .HasForeignKey(d => d.Idworksheet)
                    .HasConstraintName("areaquantity_idworksheet_fkey");
            });

            modelBuilder.Entity<Areasquantity>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("areasquantities");

                entity.Property(e => e.Areacode).HasColumnName("areacode");

                entity.Property(e => e.Areaname).HasColumnName("areaname");

                entity.Property(e => e.Createdat).HasColumnName("createdat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idarea).HasColumnName("idarea");

                entity.Property(e => e.Idcodesdimensions).HasColumnName("idcodesdimensions");

                entity.Property(e => e.Iduser).HasColumnName("iduser");

                entity.Property(e => e.Idworksheet).HasColumnName("idworksheet");

                entity.Property(e => e.Initials).HasColumnName("initials");

                entity.Property(e => e.Lengthdimensions).HasColumnName("lengthdimensions");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Rowindex).HasColumnName("rowindex");
            });

            modelBuilder.Entity<Codesdimension>(entity =>
            {
                entity.ToTable("codesdimensions");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Kind).HasColumnName("kind");
            });

            modelBuilder.Entity<Quoteandmetric>(entity =>
            {
                entity.ToTable("quoteandmetric");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Valuation).HasColumnName("valuation");
            });

            modelBuilder.Entity<Quoteandprice>(entity =>
            {
                entity.ToTable("quoteandprice");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idquoteandmetric).HasColumnName("idquoteandmetric");

                entity.Property(e => e.Iduser).HasColumnName("iduser");

                entity.Property(e => e.Idvendor).HasColumnName("idvendor");

                entity.Property(e => e.Idworksheet).HasColumnName("idworksheet");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Rowindex).HasColumnName("rowindex");

                entity.HasOne(d => d.IdquoteandmetricNavigation)
                    .WithMany(p => p.Quoteandprices)
                    .HasForeignKey(d => d.Idquoteandmetric)
                    .HasConstraintName("quoteandprice_idquoteandmetric_fkey");

                entity.HasOne(d => d.IduserNavigation)
                    .WithMany(p => p.Quoteandprices)
                    .HasForeignKey(d => d.Iduser)
                    .HasConstraintName("quoteandprice_iduser_fkey");

                entity.HasOne(d => d.IdvendorNavigation)
                    .WithMany(p => p.Quoteandprices)
                    .HasForeignKey(d => d.Idvendor)
                    .HasConstraintName("quoteandprice_idvendor_fkey");

                entity.HasOne(d => d.IdworksheetNavigation)
                    .WithMany(p => p.Quoteandprices)
                    .HasForeignKey(d => d.Idworksheet)
                    .HasConstraintName("quoteandprice_idworksheet_fkey");
            });

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

                entity.Property(e => e.Initials).HasColumnName("initials");

                entity.Property(e => e.Lastname).HasColumnName("lastname");

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.Token).HasColumnName("token");

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

                entity.Property(e => e.Token).HasColumnName("token");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.ToTable("vendors");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
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
