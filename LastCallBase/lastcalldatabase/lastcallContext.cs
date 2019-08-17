using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LastCallBase.LastCallDatabase
{
    public partial class lastcallContext : DbContext
    {
        public lastcallContext()
        {
        }

        public lastcallContext(DbContextOptions<lastcallContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Foodpreferences> Foodpreferences { get; set; }
        public virtual DbSet<Foodtypes> Foodtypes { get; set; }
        public virtual DbSet<Subscribers> Subscribers { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
        public virtual DbSet<Tbloffers> Tbloffers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=lastcall;password=lastcall;database=lastcall");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Foodpreferences>(entity =>
            {
                entity.ToTable("foodpreferences", "lastcall");

                entity.HasIndex(e => e.Preferenceid)
                    .HasName("fk_foodtype");

                entity.HasIndex(e => e.Subscriberid)
                    .HasName("ix_subscriberid");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Preferenceid)
                    .HasColumnName("preferenceid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Subscriberid)
                    .HasColumnName("subscriberid")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Preference)
                    .WithMany(p => p.Foodpreferences)
                    .HasForeignKey(d => d.Preferenceid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_foodtype");
            });

            modelBuilder.Entity<Foodtypes>(entity =>
            {
                entity.ToTable("foodtypes", "lastcall");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Foodtype)
                    .IsRequired()
                    .HasColumnName("foodtype")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Subscribers>(entity =>
            {
                entity.ToTable("subscribers", "lastcall");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Deliveryaddress)
                    .HasColumnName("deliveryaddress")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Emailoffers)
                    .HasColumnName("emailoffers")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Friendlyname)
                    .HasColumnName("friendlyname")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Onmailinglist)
                    .HasColumnName("onmailinglist")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Textoffers)
                    .HasColumnName("textoffers")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Suppliers>(entity =>
            {
                entity.ToTable("suppliers", "lastcall");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Logo)
                    .HasColumnName("logo")
                    .HasColumnType("blob");

                entity.Property(e => e.Mapurl)
                    .HasColumnName("mapurl")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.NewTablecol)
                    .HasColumnName("new_tablecol")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tbloffers>(entity =>
            {
                entity.ToTable("tbloffers", "lastcall");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Foodtype)
                    .HasColumnName("foodtype")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Offerdate).HasColumnName("offerdate");

                entity.Property(e => e.Offerdescription)
                    .HasColumnName("offerdescription")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Offerendtime).HasColumnName("offerendtime");

                entity.Property(e => e.Offername)
                    .HasColumnName("offername")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Offerstarttime).HasColumnName("offerstarttime");

                entity.Property(e => e.Qtyavailable)
                    .HasColumnName("qtyavailable")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Supplier)
                    .HasColumnName("supplier")
                    .HasColumnType("int(11)");
            });
        }
    }
}
