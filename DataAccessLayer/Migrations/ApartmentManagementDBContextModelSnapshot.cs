// <auto-generated />
using System;
using DataAccess.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(ApartmentManagementDBContext))]
    partial class ApartmentManagementDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Entities.Apartment", b =>
                {
                    b.Property<int>("ApartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("ApartmentNo")
                        .HasColumnType("tinyint");

                    b.Property<string>("Block")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("Floor")
                        .HasColumnType("smallint");

                    b.Property<bool>("IsFilled")
                        .HasColumnType("bit");

                    b.Property<string>("TypeOf")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ApartmentId");

                    b.ToTable("Apartments");
                });

            modelBuilder.Entity("Models.Entities.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApartmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("InvoiceQuantity")
                        .HasColumnType("real");

                    b.Property<int>("InvoiceTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.HasKey("InvoiceId");

                    b.HasIndex("ApartmentId");

                    b.HasIndex("InvoiceTypeId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("Models.Entities.InvoiceType", b =>
                {
                    b.Property<int>("InvoiceTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("InvoiceTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InvoiceTypeId");

                    b.ToTable("InvoiceTypes");
                });

            modelBuilder.Entity("Models.Entities.Permission", b =>
                {
                    b.Property<int>("PermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PermissionId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("Models.Entities.Tenant", b =>
                {
                    b.Property<int>("TenantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApartmentId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TenantId");

                    b.HasIndex("ApartmentId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("Models.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserRole")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Models.Entities.UserPassword", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserPasswords");
                });

            modelBuilder.Entity("Models.Entities.UserPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<int>("PermissionId1")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.HasIndex("PermissionId1");

                    b.ToTable("UserPermissions");
                });

            modelBuilder.Entity("Models.Entities.Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LicensePlate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("VehicleId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("Models.Entities.Invoice", b =>
                {
                    b.HasOne("Models.Entities.Apartment", "Apartment")
                        .WithMany()
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.InvoiceType", "InvoiceType")
                        .WithMany()
                        .HasForeignKey("InvoiceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Apartment");

                    b.Navigation("InvoiceType");
                });

            modelBuilder.Entity("Models.Entities.Tenant", b =>
                {
                    b.HasOne("Models.Entities.Apartment", "Apartment")
                        .WithMany("Tenants")
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.User", "User")
                        .WithOne("Tenant")
                        .HasForeignKey("Models.Entities.Tenant", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Apartment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.Entities.UserPassword", b =>
                {
                    b.HasOne("Models.Entities.User", "User")
                        .WithOne("Password")
                        .HasForeignKey("Models.Entities.UserPassword", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.Entities.UserPermission", b =>
                {
                    b.HasOne("Models.Entities.User", "User")
                        .WithMany("UserPermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.Permission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.Entities.Vehicle", b =>
                {
                    b.HasOne("Models.Entities.User", "User")
                        .WithOne("Vehicle")
                        .HasForeignKey("Models.Entities.Vehicle", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.Entities.Apartment", b =>
                {
                    b.Navigation("Tenants");
                });

            modelBuilder.Entity("Models.Entities.User", b =>
                {
                    b.Navigation("Password");

                    b.Navigation("Tenant");

                    b.Navigation("UserPermissions");

                    b.Navigation("Vehicle");
                });
#pragma warning restore 612, 618
        }
    }
}
