using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AspSonatelRH.Models
{
    public partial class RHDbContext : DbContext
    {
        public RHDbContext()
        {
        }

        public RHDbContext(DbContextOptions<RHDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Candidat> Candidat { get; set; }
        public virtual DbSet<Direction> Direction { get; set; }
        public virtual DbSet<Poste> Poste { get; set; }
        public virtual DbSet<Typerecrutement> Typerecrutement { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=localhost;User Id=root;Password=;Database=sonatel_rh");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidat>(entity =>
            {
                entity.HasKey(e => e.IdCandidat)
                    .HasName("PRIMARY");

                entity.ToTable("candidat");

                entity.HasIndex(e => e.IdPoste)
                    .HasName("idPoste");

                entity.Property(e => e.IdCandidat)
                    .HasColumnName("idCandidat")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DatePriseFonction)
                    .HasColumnName("datePriseFonction")
                    .HasColumnType("date");

                entity.Property(e => e.IdPoste)
                    .HasColumnName("idPoste")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LieuNaissance)
                    .IsRequired()
                    .HasColumnName("lieuNaissance")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.NomCandidat)
                    .IsRequired()
                    .HasColumnName("nomCandidat")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.PrenomCandidat)
                    .IsRequired()
                    .HasColumnName("prenomCandidat")
                    .HasColumnType("varchar(70)");

                entity.HasOne(d => d.IdPosteNavigation)
                    .WithMany(p => p.Candidat)
                    .HasForeignKey(d => d.IdPoste)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("candidat_ibfk_1");
            });

            modelBuilder.Entity<Direction>(entity =>
            {
                entity.HasKey(e => e.IdDirection)
                    .HasName("PRIMARY");

                entity.ToTable("direction");

                entity.Property(e => e.IdDirection)
                    .HasColumnName("idDirection")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodeDirection)
                    .IsRequired()
                    .HasColumnName("codeDirection")
                    .HasColumnType("varchar(7)");

                entity.Property(e => e.LibelleDirection)
                    .IsRequired()
                    .HasColumnName("libelleDirection")
                    .HasColumnType("varchar(115)");
            });

            modelBuilder.Entity<Poste>(entity =>
            {
                entity.HasKey(e => e.IdPoste)
                    .HasName("PRIMARY");

                entity.ToTable("poste");

                entity.HasIndex(e => e.IdDirection)
                    .HasName("idDirection");

                entity.HasIndex(e => e.IdTypeRecrutement)
                    .HasName("idTypeRecrutement");

                entity.Property(e => e.IdPoste)
                    .HasColumnName("idPoste")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CompetenceRequise)
                    .IsRequired()
                    .HasColumnName("competenceRequise")
                    .HasColumnType("longtext");

                entity.Property(e => e.DeuxiemeCommission)
                    .HasColumnName("deuxiemeCommission")
                    .HasColumnType("date");

                entity.Property(e => e.IdDirection)
                    .HasColumnName("idDirection")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTypeRecrutement)
                    .HasColumnName("idTypeRecrutement")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IntitulePoste)
                    .IsRequired()
                    .HasColumnName("intitulePoste")
                    .HasColumnType("varchar(75)");

                entity.Property(e => e.PremierCommission)
                    .HasColumnName("premierCommission")
                    .HasColumnType("date");

                entity.Property(e => e.SitePoste)
                    .IsRequired()
                    .HasColumnName("sitePoste")
                    .HasColumnType("varchar(175)");

                entity.HasOne(d => d.IdDirectionNavigation)
                    .WithMany(p => p.Poste)
                    .HasForeignKey(d => d.IdDirection)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("poste_ibfk_1");

                entity.HasOne(d => d.IdTypeRecrutementNavigation)
                    .WithMany(p => p.Poste)
                    .HasForeignKey(d => d.IdTypeRecrutement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("poste_ibfk_2");
            });

            modelBuilder.Entity<Typerecrutement>(entity =>
            {
                entity.HasKey(e => e.IdTypeRecrutement)
                    .HasName("PRIMARY");

                entity.ToTable("typerecrutement");

                entity.Property(e => e.IdTypeRecrutement)
                    .HasColumnName("idTypeRecrutement")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LibelleTypeRecrutement)
                    .IsRequired()
                    .HasColumnName("libelleTypeRecrutement")
                    .HasColumnType("enum('Interne','Externe')");
            });
        }
    }
}
