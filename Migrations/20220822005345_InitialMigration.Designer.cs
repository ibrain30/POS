// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using POS.Models.DB;

namespace POS.Migrations
{
    [DbContext(typeof(PosProduitContext))]
    [Migration("20220822005345_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("POS.Models.DB.Categorie", b =>
                {
                    b.Property<int>("IdCateg")
                        .HasColumnType("int")
                        .HasColumnName("Id_Categ");

                    b.Property<string>("NomCateg")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("Nom_Categ");

                    b.Property<int?>("Statu")
                        .HasColumnType("int");

                    b.HasKey("IdCateg")
                        .HasName("PK__Categori__40D081D91624232B");

                    b.ToTable("Categorie");
                });

            modelBuilder.Entity("POS.Models.DB.DetailsVente", b =>
                {
                    b.Property<int>("IdDetailVente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_Detail_Vente")
                        .UseIdentityColumn();

                    b.Property<int>("IdProd")
                        .HasColumnType("int")
                        .HasColumnName("Id_Prod");

                    b.Property<int>("IdVente")
                        .HasColumnType("int")
                        .HasColumnName("Id_Vente");

                    b.Property<double>("Prix")
                        .HasColumnType("float");

                    b.Property<int>("Quantite")
                        .HasColumnType("int");

                    b.Property<double>("TotalDetailV")
                        .HasColumnType("float")
                        .HasColumnName("Total_Detail_V");

                    b.HasKey("IdDetailVente")
                        .HasName("PK__DetailsV__A74CAD29F24C305C");

                    b.HasIndex("IdProd");

                    b.HasIndex("IdVente");

                    b.ToTable("DetailsVente");
                });

            modelBuilder.Entity("POS.Models.DB.Posproduit", b =>
                {
                    b.Property<int>("IdProd")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_Prod")
                        .UseIdentityColumn();

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("IdCateg")
                        .HasColumnType("int")
                        .HasColumnName("Id_Categ");

                    b.HasKey("IdProd")
                        .HasName("PK__POSProdu__3A592ADFDA1291ED");

                    b.HasIndex("IdCateg");

                    b.ToTable("POSProduits");
                });

            modelBuilder.Entity("POS.Models.DB.QuantProduit", b =>
                {
                    b.Property<int>("IdQp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_QP")
                        .UseIdentityColumn();

                    b.Property<int>("IdProd")
                        .HasColumnType("int")
                        .HasColumnName("Id_Prod");

                    b.Property<int>("Quantite")
                        .HasColumnType("int");

                    b.HasKey("IdQp")
                        .HasName("PK__Quant_Pr__16EC0022E69D11EA");

                    b.HasIndex("IdProd");

                    b.ToTable("Quant_Produit");
                });

            modelBuilder.Entity("POS.Models.DB.Utilisateur", b =>
                {
                    b.Property<int>("IdUtil")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_Util")
                        .UseIdentityColumn();

                    b.Property<string>("Identifiant")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MotDePasse")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Mot_De_Passe");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdUtil")
                        .HasName("PK__Utilisat__D07DCB5F4505F612");

                    b.ToTable("Utilisateur");
                });

            modelBuilder.Entity("POS.Models.DB.Vente", b =>
                {
                    b.Property<int>("IdVente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_Vente")
                        .UseIdentityColumn();

                    b.Property<string>("AdrClient")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Adr_Client");

                    b.Property<DateTime>("DateVente")
                        .HasColumnType("date")
                        .HasColumnName("Date_Vente");

                    b.Property<string>("MethodPayment")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Method_Payment");

                    b.Property<string>("NomClient")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Nom_Client");

                    b.Property<string>("NumVente")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Num_Vente");

                    b.Property<string>("TelClient")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Tel_Client");

                    b.Property<double?>("Total")
                        .HasColumnType("float");

                    b.HasKey("IdVente")
                        .HasName("PK__Vente__B3C9EAB9515E6F87");

                    b.ToTable("Vente");
                });

            modelBuilder.Entity("POS.Models.DB.DetailsVente", b =>
                {
                    b.HasOne("POS.Models.DB.Posproduit", "IdProdNavigation")
                        .WithMany("DetailsVentes")
                        .HasForeignKey("IdProd")
                        .HasConstraintName("FK_PRODUIT")
                        .IsRequired();

                    b.HasOne("POS.Models.DB.Vente", "IdVenteNavigation")
                        .WithMany("DetailsVentes")
                        .HasForeignKey("IdVente")
                        .HasConstraintName("FK_VENTE")
                        .IsRequired();

                    b.Navigation("IdProdNavigation");

                    b.Navigation("IdVenteNavigation");
                });

            modelBuilder.Entity("POS.Models.DB.Posproduit", b =>
                {
                    b.HasOne("POS.Models.DB.Categorie", "IdCategNavigation")
                        .WithMany("Posproduits")
                        .HasForeignKey("IdCateg")
                        .IsRequired();

                    b.Navigation("IdCategNavigation");
                });

            modelBuilder.Entity("POS.Models.DB.QuantProduit", b =>
                {
                    b.HasOne("POS.Models.DB.Posproduit", "IdProdNavigation")
                        .WithMany("QuantProduits")
                        .HasForeignKey("IdProd")
                        .HasConstraintName("FK_Quant_Produit_PRODUIT_Id_Prod")
                        .IsRequired();

                    b.Navigation("IdProdNavigation");
                });

            modelBuilder.Entity("POS.Models.DB.Categorie", b =>
                {
                    b.Navigation("Posproduits");
                });

            modelBuilder.Entity("POS.Models.DB.Posproduit", b =>
                {
                    b.Navigation("DetailsVentes");

                    b.Navigation("QuantProduits");
                });

            modelBuilder.Entity("POS.Models.DB.Vente", b =>
                {
                    b.Navigation("DetailsVentes");
                });
#pragma warning restore 612, 618
        }
    }
}
