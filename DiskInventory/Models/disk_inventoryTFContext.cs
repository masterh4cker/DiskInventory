using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DiskInventory.Models
{
    public partial class disk_inventoryTFContext : DbContext
    {
        public disk_inventoryTFContext()
        {
        }

        public disk_inventoryTFContext(DbContextOptions<disk_inventoryTFContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artist> Artist { get; set; }
        public virtual DbSet<ArtistType> ArtistType { get; set; }
        public virtual DbSet<Disk> Disk { get; set; }
        public virtual DbSet<DiskHasArtist> DiskHasArtist { get; set; }
        public virtual DbSet<DiskHasRenter> DiskHasRenter { get; set; }
        public virtual DbSet<DiskType> DiskType { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Renter> Renter { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<ViewIndividualArtist> ViewIndividualArtist { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Server=.\\SQLDEV01;Database=disk_inventoryTF;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>(entity =>
            {
                entity.ToTable("artist");

                entity.Property(e => e.ArtistId).HasColumnName("artist_id");

                entity.Property(e => e.ArtistTypeId).HasColumnName("artist_type_id");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasMaxLength(60);

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(60);

                entity.HasOne(d => d.ArtistType)
                    .WithMany(p => p.Artist)
                    .HasForeignKey(d => d.ArtistTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__artist__artist_t__2D27B809");
            });

            modelBuilder.Entity<ArtistType>(entity =>
            {
                entity.ToTable("artist_type");

                entity.Property(e => e.ArtistTypeId).HasColumnName("artist_type_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<Disk>(entity =>
            {
                entity.ToTable("disk");

                entity.Property(e => e.DiskId).HasColumnName("disk_id");

                entity.Property(e => e.DiskName)
                    .IsRequired()
                    .HasColumnName("disk_name")
                    .HasMaxLength(60);

                entity.Property(e => e.DiskTypeId).HasColumnName("disk_type_id");

                entity.Property(e => e.GenreId).HasColumnName("genre_id");

                entity.Property(e => e.ReleaseDate)
                    .HasColumnName("release_date")
                    .HasColumnType("date");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.HasOne(d => d.DiskType)
                    .WithMany(p => p.Disk)
                    .HasForeignKey(d => d.DiskTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__disk__disk_type___31EC6D26");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Disk)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__disk__genre_id__300424B4");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Disk)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__disk__status_id__30F848ED");
            });

            modelBuilder.Entity<DiskHasArtist>(entity =>
            {
                entity.HasKey(e => new { e.DiskId, e.ArtistId })
                    .HasName("PK__disk_has__2DAE42F0C6047B4A");

                entity.ToTable("disk_has_artist");

                entity.Property(e => e.DiskId).HasColumnName("disk_id");

                entity.Property(e => e.ArtistId).HasColumnName("artist_id");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.DiskHasArtist)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__disk_has___artis__398D8EEE");

                entity.HasOne(d => d.Disk)
                    .WithMany(p => p.DiskHasArtist)
                    .HasForeignKey(d => d.DiskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__disk_has___disk___38996AB5");
            });

            modelBuilder.Entity<DiskHasRenter>(entity =>
            {
                //entity.HasKey(e => new { e.RenterId, e.DiskId })
                    //.HasName("PK__disk_has__42F5BB64A2E64220");

                entity.ToTable("disk_has_renter");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.RenterId).HasColumnName("renter_id");

                entity.Property(e => e.DiskId).HasColumnName("disk_id");

                entity.Property(e => e.RentDate).HasColumnName("rent_date");

                entity.Property(e => e.ReturnedDate).HasColumnName("returned_date");

                entity.HasOne(d => d.Disk)
                    .WithMany(p => p.DiskHasRenter)
                    .HasForeignKey(d => d.DiskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__disk_has___disk___35BCFE0A");

                entity.HasOne(d => d.Renter)
                    .WithMany(p => p.DiskHasRenter)
                    .HasForeignKey(d => d.RenterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__disk_has___rente__34C8D9D1");
            });

            modelBuilder.Entity<DiskType>(entity =>
            {
                entity.ToTable("disk_type");

                entity.Property(e => e.DiskTypeId).HasColumnName("disk_type_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genre");

                entity.Property(e => e.GenreId).HasColumnName("genre_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<Renter>(entity =>
            {
                entity.ToTable("renter");

                entity.Property(e => e.RenterId).HasColumnName("renter_id");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasMaxLength(60);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasMaxLength(60);

                entity.Property(e => e.PhoneNum)
                    .IsRequired()
                    .HasColumnName("phone_num")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("status");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<ViewIndividualArtist>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Individual_Artist");

                entity.Property(e => e.ArtistFirstName)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.DiskName)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.ReleaseDate).HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
