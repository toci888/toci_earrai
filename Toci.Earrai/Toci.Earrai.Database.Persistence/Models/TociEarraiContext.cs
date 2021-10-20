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
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Categorygroup> Categorygroups { get; set; }
        public virtual DbSet<Codesdimension> Codesdimensions { get; set; }
        public virtual DbSet<Commision> Commisions { get; set; }
        public virtual DbSet<Density> Densities { get; set; }
        public virtual DbSet<Densitymaterial> Densitymaterials { get; set; }
        public virtual DbSet<Densityopdict> Densityopdicts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Productcategoryoption> Productcategoryoptions { get; set; }
        public virtual DbSet<Productoption> Productoptions { get; set; }
        public virtual DbSet<Productoptionvalue> Productoptionvalues { get; set; }
        public virtual DbSet<Productsize> Productsizes { get; set; }
        public virtual DbSet<Productsoptionsstate> Productsoptionsstates { get; set; }
        public virtual DbSet<Productssize> Productssizes { get; set; }
        public virtual DbSet<Quoteandmetric> Quoteandmetrics { get; set; }
        public virtual DbSet<Quoteandprice> Quoteandprices { get; set; }
        public virtual DbSet<Quotesandprice> Quotesandprices { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<Sizecategory> Sizecategories { get; set; }
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
            modelBuilder.HasAnnotation("Relational:Collation", "English_United States.1252");

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

                entity.Property(e => e.Idproducts).HasColumnName("idproducts");

                entity.Property(e => e.Iduser).HasColumnName("iduser");

                entity.Property(e => e.Length).HasColumnName("length");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Rowindex).HasColumnName("rowindex");

                entity.Property(e => e.Updatedat)
                    .HasColumnName("updatedat")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Width).HasColumnName("width");

                entity.HasOne(d => d.IdareaNavigation)
                    .WithMany(p => p.Areaquantities)
                    .HasForeignKey(d => d.Idarea)
                    .HasConstraintName("areaquantity_idarea_fkey");

                entity.HasOne(d => d.IdcodesdimensionsNavigation)
                    .WithMany(p => p.Areaquantities)
                    .HasForeignKey(d => d.Idcodesdimensions)
                    .HasConstraintName("areaquantity_idcodesdimensions_fkey");

                entity.HasOne(d => d.IdproductsNavigation)
                    .WithMany(p => p.Areaquantities)
                    .HasForeignKey(d => d.Idproducts)
                    .HasConstraintName("areaquantity_idproducts_fkey");

                entity.HasOne(d => d.IduserNavigation)
                    .WithMany(p => p.Areaquantities)
                    .HasForeignKey(d => d.Iduser)
                    .HasConstraintName("areaquantity_iduser_fkey");
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

                entity.Property(e => e.Idproducts).HasColumnName("idproducts");

                entity.Property(e => e.Iduser).HasColumnName("iduser");

                entity.Property(e => e.Initials).HasColumnName("initials");

                entity.Property(e => e.Length).HasColumnName("length");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Rowindex).HasColumnName("rowindex");

                entity.Property(e => e.Width).HasColumnName("width");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Idcategorygroups).HasColumnName("idcategorygroups");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Prefix).HasColumnName("prefix");

                entity.HasOne(d => d.IdcategorygroupsNavigation)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.Idcategorygroups)
                    .HasConstraintName("categories_idcategorygroups_fkey");
            });

            modelBuilder.Entity<Categorygroup>(entity =>
            {
                entity.ToTable("categorygroups");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Codesdimension>(entity =>
            {
                entity.ToTable("codesdimensions");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Kind).HasColumnName("kind");
            });

            modelBuilder.Entity<Commision>(entity =>
            {
                entity.ToTable("commisions");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idcategories).HasColumnName("idcategories");

                entity.Property(e => e.Quotient).HasColumnName("quotient");

                entity.Property(e => e.Title).HasColumnName("title");

                entity.HasOne(d => d.IdcategoriesNavigation)
                    .WithMany(p => p.Commisions)
                    .HasForeignKey(d => d.Idcategories)
                    .HasConstraintName("commisions_idcategories_fkey");
            });

            modelBuilder.Entity<Density>(entity =>
            {
                entity.ToTable("density");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Iddensitymaterial).HasColumnName("iddensitymaterial");

                entity.Property(e => e.Iddensityopdict).HasColumnName("iddensityopdict");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.HasOne(d => d.IddensitymaterialNavigation)
                    .WithMany(p => p.Densities)
                    .HasForeignKey(d => d.Iddensitymaterial)
                    .HasConstraintName("density_iddensitymaterial_fkey");

                entity.HasOne(d => d.IddensityopdictNavigation)
                    .WithMany(p => p.Densities)
                    .HasForeignKey(d => d.Iddensityopdict)
                    .HasConstraintName("density_iddensityopdict_fkey");
            });

            modelBuilder.Entity<Densitymaterial>(entity =>
            {
                entity.ToTable("densitymaterial");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Densityopdict>(entity =>
            {
                entity.ToTable("densityopdict");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Idcategories).HasColumnName("idcategories");

                entity.Property(e => e.Idworksheet).HasColumnName("idworksheet");

                entity.Property(e => e.Productaccountreference).HasColumnName("productaccountreference");

                entity.Property(e => e.Rowindex).HasColumnName("rowindex");

                entity.HasOne(d => d.IdcategoriesNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Idcategories)
                    .HasConstraintName("products_idcategories_fkey");

                entity.HasOne(d => d.IdworksheetNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Idworksheet)
                    .HasConstraintName("products_idworksheet_fkey");
            });

            modelBuilder.Entity<Productcategoryoption>(entity =>
            {
                entity.ToTable("productcategoryoptions");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idcategories).HasColumnName("idcategories");

                entity.Property(e => e.Idproductoptions).HasColumnName("idproductoptions");

                entity.HasOne(d => d.IdcategoriesNavigation)
                    .WithMany(p => p.Productcategoryoptions)
                    .HasForeignKey(d => d.Idcategories)
                    .HasConstraintName("productcategoryoptions_idcategories_fkey");

                entity.HasOne(d => d.IdproductoptionsNavigation)
                    .WithMany(p => p.Productcategoryoptions)
                    .HasForeignKey(d => d.Idproductoptions)
                    .HasConstraintName("productcategoryoptions_idproductoptions_fkey");
            });

            modelBuilder.Entity<Productoption>(entity =>
            {
                entity.ToTable("productoptions");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Productoptionvalue>(entity =>
            {
                entity.ToTable("productoptionvalues");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idproductoptions).HasColumnName("idproductoptions");

                entity.Property(e => e.Idproducts).HasColumnName("idproducts");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.HasOne(d => d.IdproductoptionsNavigation)
                    .WithMany(p => p.Productoptionvalues)
                    .HasForeignKey(d => d.Idproductoptions)
                    .HasConstraintName("productoptionvalues_idproductoptions_fkey");

                entity.HasOne(d => d.IdproductsNavigation)
                    .WithMany(p => p.Productoptionvalues)
                    .HasForeignKey(d => d.Idproducts)
                    .HasConstraintName("productoptionvalues_idproducts_fkey");
            });

            modelBuilder.Entity<Productsize>(entity =>
            {
                entity.ToTable("productsize");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idproducts).HasColumnName("idproducts");

                entity.Property(e => e.Idsizes).HasColumnName("idsizes");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.HasOne(d => d.IdproductsNavigation)
                    .WithMany(p => p.Productsizes)
                    .HasForeignKey(d => d.Idproducts)
                    .HasConstraintName("productsize_idproducts_fkey");

                entity.HasOne(d => d.IdsizesNavigation)
                    .WithMany(p => p.Productsizes)
                    .HasForeignKey(d => d.Idsizes)
                    .HasConstraintName("productsize_idsizes_fkey");
            });

            modelBuilder.Entity<Productsoptionsstate>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("productsoptionsstate");

                entity.Property(e => e.Idproducts).HasColumnName("idproducts");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<Productssize>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("productssizes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idproducts).HasColumnName("idproducts");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<Quoteandmetric>(entity =>
            {
                entity.ToTable("quoteandmetric");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Valuation).HasColumnName("valuation");
            });

            modelBuilder.Entity<Quoteandprice>(entity =>
            {
                entity.ToTable("quoteandprice");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idproducts).HasColumnName("idproducts");

                entity.Property(e => e.Idquoteandmetric).HasColumnName("idquoteandmetric");

                entity.Property(e => e.Iduser).HasColumnName("iduser");

                entity.Property(e => e.Idvendor).HasColumnName("idvendor");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Rowindex).HasColumnName("rowindex");

                entity.HasOne(d => d.IdproductsNavigation)
                    .WithMany(p => p.Quoteandprices)
                    .HasForeignKey(d => d.Idproducts)
                    .HasConstraintName("quoteandprice_idproducts_fkey");

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
            });

            modelBuilder.Entity<Quotesandprice>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("quotesandprices");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idproducts).HasColumnName("idproducts");

                entity.Property(e => e.Idquoteandmetric).HasColumnName("idquoteandmetric");

                entity.Property(e => e.Iduser).HasColumnName("iduser");

                entity.Property(e => e.Idvendor).HasColumnName("idvendor");

                entity.Property(e => e.Initials).HasColumnName("initials");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Rowindex).HasColumnName("rowindex");

                entity.Property(e => e.Valuation).HasColumnName("valuation");

                entity.Property(e => e.Vendor).HasColumnName("vendor");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.ToTable("sizes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Sizecategory>(entity =>
            {
                entity.ToTable("sizecategories");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idcategories).HasColumnName("idcategories");

                entity.Property(e => e.Idsizes).HasColumnName("idsizes");

                entity.HasOne(d => d.IdcategoriesNavigation)
                    .WithMany(p => p.Sizecategories)
                    .HasForeignKey(d => d.Idcategories)
                    .HasConstraintName("sizecategories_idcategories_fkey");

                entity.HasOne(d => d.IdsizesNavigation)
                    .WithMany(p => p.Sizecategories)
                    .HasForeignKey(d => d.Idsizes)
                    .HasConstraintName("sizecategories_idsizes_fkey");
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
