using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace POS.Models.DB
{
    public partial class PosProduitContext : DbContext
    {
        public PosProduitContext()
        {
        }

        public PosProduitContext(DbContextOptions<PosProduitContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorie> Categories { get; set; }
        public virtual DbSet<DetailsVente> DetailsVentes { get; set; }
        public virtual DbSet<Posproduit> Posproduits { get; set; }
        public virtual DbSet<QuantProduit> QuantProduits { get; set; }
        public virtual DbSet<Utilisateur> Utilisateurs { get; set; }
        public virtual DbSet<Vente> Ventes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("server=localhost;Database=PosProduit;User Id=sa;Password=Strong.Pwd-123;MultipleActiveResultSets=True;");
//            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorie>(entity =>
            {
                entity.HasKey(e => e.IdCateg)
                    .HasName("PK__Categori__40D081D91624232B");

                entity.ToTable("Categorie");

                entity.Property(e => e.IdCateg)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Categ");

                entity.Property(e => e.NomCateg)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Nom_Categ");
            });

            modelBuilder.Entity<DetailsVente>(entity =>
            {
                entity.HasKey(e => e.IdDetailVente)
                    .HasName("PK__DetailsV__A74CAD29F24C305C");

                entity.ToTable("DetailsVente");

                entity.Property(e => e.IdDetailVente).HasColumnName("Id_Detail_Vente");

                entity.Property(e => e.IdProd).HasColumnName("Id_Prod");

                entity.Property(e => e.IdVente).HasColumnName("Id_Vente");

                entity.Property(e => e.TotalDetailV).HasColumnName("Total_Detail_V");

                entity.HasOne(d => d.IdProdNavigation)
                    .WithMany(p => p.DetailsVentes)
                    .HasForeignKey(d => d.IdProd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUIT");

                entity.HasOne(d => d.IdVenteNavigation)
                    .WithMany(p => p.DetailsVentes)
                    .HasForeignKey(d => d.IdVente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VENTE");
            });

            modelBuilder.Entity<Posproduit>(entity =>
            {
                entity.HasKey(e => e.IdProd)
                    .HasName("PK__POSProdu__3A592ADFDA1291ED");

                entity.ToTable("POSProduits");

                entity.Property(e => e.IdProd).HasColumnName("Id_Prod");

                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IdCateg).HasColumnName("Id_Categ");

                entity.HasOne(d => d.IdCategNavigation)
                    .WithMany(p => p.Posproduits)
                    .HasForeignKey(d => d.IdCateg)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<QuantProduit>(entity =>
            {
                entity.HasKey(e => e.IdQp)
                    .HasName("PK__Quant_Pr__16EC0022E69D11EA");

                entity.ToTable("Quant_Produit");

                entity.Property(e => e.IdQp).HasColumnName("Id_QP");

                entity.Property(e => e.IdProd).HasColumnName("Id_Prod");

                entity.HasOne(d => d.IdProdNavigation)
                    .WithMany(p => p.QuantProduits)
                    .HasForeignKey(d => d.IdProd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Quant_Produit_PRODUIT_Id_Prod");
            });

            modelBuilder.Entity<Utilisateur>(entity =>
            {
                entity.HasKey(e => e.IdUtil)
                    .HasName("PK__Utilisat__D07DCB5F4505F612");

                entity.ToTable("Utilisateur");

                entity.Property(e => e.IdUtil).HasColumnName("Id_Util");

                entity.Property(e => e.Identifiant)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.MotDePasse)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("Mot_De_Passe");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Vente>(entity =>
            {
                entity.HasKey(e => e.IdVente)
                    .HasName("PK__Vente__B3C9EAB9515E6F87");

                entity.ToTable("Vente");

                entity.Property(e => e.IdVente).HasColumnName("Id_Vente");

                entity.Property(e => e.AdrClient)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Adr_Client");

                entity.Property(e => e.DateVente)
                    .HasColumnType("date")
                    .HasColumnName("Date_Vente");

                entity.Property(e => e.MethodPayment)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Method_Payment");

                entity.Property(e => e.NomClient)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Nom_Client");

                entity.Property(e => e.NumVente)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("Num_Vente");

                entity.Property(e => e.TelClient)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Tel_Client");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
