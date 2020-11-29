using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PhoneContact.EFRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneContact.API.Migrations
{
    [DbContext(typeof(PhoneContactContext))]
    [Migration("20201120133730_InitMigration")]
    partial class InitMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        { 
            modelBuilder
             .HasAnnotation("ProductVersion", "3.1.0")
             .HasAnnotation("Relational:MaxIdentifierLength", 128)
             .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PhoneContact.Domain.Entities.Contact", m =>
            {
                m.Property<long>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("bigint");

                m.Property<Guid>("UIID")
                    .ValueGeneratedOnAdd()
                    .IsRequired()
                    .HasColumnType("uniqueidentifier");

                m.Property<DateTimeOffset>("CreateDate")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("datetime");

                m.Property<DateTimeOffset>("UpdateDate")
                    .HasColumnType("datetime");

                m.Property<bool>("IsDeleted")
                    .HasColumnType("bit");

                m.Property<string>("FirstName")
                    .IsRequired()
                    .HasColumnType("nvarchar(200)")
                    .HasMaxLength(200);

                m.Property<string>("FirstName")
                    .IsRequired()
                    .HasColumnType("nvarchar(200)")
                    .HasMaxLength(200);

                m.Property<string>("MiddleName")
                    .HasColumnType("nvarchar(200)")
                    .HasMaxLength(200);

                m.Property<string>("LastName")
                    .IsRequired()
                    .HasColumnType("nvarchar(200)")
                    .HasMaxLength(200);

                m.Property<string>("CompanyName")
                    .HasColumnType("nvarchar(200)")
                    .HasMaxLength(200);

                m.HasKey("Id");

                m.ToTable("Contact", "dbo");
            });

            //modelBuilder.Entity("BookShop.Domain.Entities.Book", b =>
            //{
            //    b.Property<Guid>("Id")
            //        .ValueGeneratedOnAdd()
            //        .HasColumnType("uniqueidentifier");

            //    b.Property<Guid>("AuthorId")
            //        .HasColumnType("uniqueidentifier");

            //    b.Property<int>("AvailableStock")
            //        .HasColumnType("int");

            //    b.Property<string>("Description")
            //        .IsRequired()
            //        .HasColumnType("nvarchar(1000)")
            //        .HasMaxLength(1000);

            //    b.Property<string>("Format")
            //        .HasColumnType("nvarchar(max)");

            //    b.Property<Guid>("GenreId")
            //        .HasColumnType("uniqueidentifier");

            //    b.Property<string>("LabelName")
            //        .HasColumnType("nvarchar(max)");

            //    b.Property<string>("Name")
            //        .IsRequired()
            //        .HasColumnType("nvarchar(max)");

            //    b.Property<string>("PictureUri")
            //        .HasColumnType("nvarchar(max)");

            //    b.Property<string>("Price")
            //        .HasColumnType("nvarchar(max)");

            //    b.Property<DateTimeOffset>("ReleaseDate")
            //        .HasColumnType("datetimeoffset");

            //    b.HasKey("Id");

            //    b.HasIndex("AuthorId");

            //    b.HasIndex("GenreId");

            //    b.ToTable("Books", "bookshop");
            //});

            //modelBuilder.Entity("BookShop.Domain.Entities.Genre", b =>
            //{
            //    b.Property<Guid>("GenreId")
            //        .ValueGeneratedOnAdd()
            //        .HasColumnType("uniqueidentifier");

            //    b.Property<string>("GenreDescription")
            //        .IsRequired()
            //        .HasColumnType("nvarchar(1000)")
            //        .HasMaxLength(1000);

            //    b.HasKey("GenreId");

            //    b.ToTable("Genres", "bookshop");
            //});

            //modelBuilder.Entity("BookShop.Domain.Entities.Book", b =>
            //{
            //    b.HasOne("BookShop.Domain.Entities.Author", "Author")
            //        .WithMany("Books")
            //        .HasForeignKey("AuthorId")
            //        .OnDelete(DeleteBehavior.Cascade)
            //        .IsRequired();

            //    b.HasOne("BookShop.Domain.Entities.Genre", "Genre")
            //        .WithMany("Books")
            //        .HasForeignKey("GenreId")
            //        .OnDelete(DeleteBehavior.Cascade)
            //        .IsRequired();
            //}); 
        }

    }
}
