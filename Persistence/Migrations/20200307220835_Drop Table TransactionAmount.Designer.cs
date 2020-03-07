﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200307220835_Drop Table TransactionAmount")]
    partial class DropTableTransactionAmount
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnName("Date Of Birth")
                        .HasColumnType("Date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("First Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("Last Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Domain.Entities.Transaction.AmountModification", b =>
                {
                    b.Property<int>("AmountModificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("AmountModificationID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("money");

                    b.Property<int>("AmountCalculationType")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Amount Calculation Type")
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("AmountType")
                        .HasColumnName("Amount Type")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("AmountModificationId");

                    b.ToTable("AmountModifications");
                });

            modelBuilder.Entity("Domain.Entities.Transaction.RecurrentTransactionCustomFrequency", b =>
                {
                    b.Property<int>("RecurrentTransactionCustomFrequencyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("RecurrentTransactionCustomFrequencyID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TimeUnit")
                        .HasColumnName("Time Unit")
                        .HasColumnType("int");

                    b.Property<int>("TimeUnitQuantity")
                        .HasColumnName("Time Unit Quantity")
                        .HasColumnType("int");

                    b.Property<int>("TransactionRecurrencyId")
                        .HasColumnType("int");

                    b.HasKey("RecurrentTransactionCustomFrequencyId");

                    b.HasIndex("TransactionRecurrencyId")
                        .IsUnique();

                    b.ToTable("RecurrentTransactionCustomFrequencies");
                });

            modelBuilder.Entity("Domain.Entities.Transaction.RecurrentTransactionInstallment", b =>
                {
                    b.Property<int>("RecurrentTransactionInstallmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("RecurrentTransactionInstallmentID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CurrentInstallment")
                        .HasColumnName("Current Installment")
                        .HasColumnType("int");

                    b.Property<DateTime>("InstallmentTriggerDate")
                        .HasColumnName("Installment Trigger Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("TransactionRecurrencyId")
                        .HasColumnType("int");

                    b.HasKey("RecurrentTransactionInstallmentId");

                    b.HasIndex("TransactionRecurrencyId");

                    b.ToTable("RecurrentTransactionInstallments");
                });

            modelBuilder.Entity("Domain.Entities.Transaction.RecurrentTransactionLimitation", b =>
                {
                    b.Property<int>("RecurrentTransactionLimitationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("RecurrentTransactionLimitationID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnName("End Date")
                        .HasColumnType("smalldatetime");

                    b.Property<decimal?>("MaxSumAmount")
                        .HasColumnName("Max Sum Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SumAmount")
                        .HasColumnName("Sum Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SumInstallments")
                        .HasColumnName("Sum Installments")
                        .HasColumnType("int");

                    b.Property<int>("TransactionRecurrencyId")
                        .HasColumnType("int");

                    b.HasKey("RecurrentTransactionLimitationId");

                    b.HasIndex("TransactionRecurrencyId")
                        .IsUnique();

                    b.ToTable("RecurrentTransactionLimitations");
                });

            modelBuilder.Entity("Domain.Entities.Transaction.RecurrentTransactionSumAmountModification", b =>
                {
                    b.Property<int>("RecurrentTransactionLimitationId")
                        .HasColumnName("RecurrentTransactionLimitationID")
                        .HasColumnType("int");

                    b.Property<int>("AmountModificationId")
                        .HasColumnName("AmountModificationID")
                        .HasColumnType("int");

                    b.HasKey("RecurrentTransactionLimitationId", "AmountModificationId");

                    b.HasIndex("AmountModificationId");

                    b.ToTable("RecurrentTransactionSumAmountModifications");
                });

            modelBuilder.Entity("Domain.Entities.Transaction.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TransactionID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("money");

                    b.Property<int>("CategoryId")
                        .HasColumnName("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("Currency")
                        .HasColumnType("int");

                    b.Property<bool>("IsRecurrent")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<decimal?>("MaxAmount")
                        .HasColumnName("Max Amount")
                        .HasColumnType("money");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("TransactionAmountId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TriggerDate")
                        .HasColumnName("Trigger Date")
                        .HasColumnType("smalldatetime");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnName("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TransactionId")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Domain.Entities.Transaction.TransactionAmountModification", b =>
                {
                    b.Property<int>("TransactionId")
                        .HasColumnName("TransactionID")
                        .HasColumnType("int");

                    b.Property<int>("AmountModificationId")
                        .HasColumnName("AmountModificationID")
                        .HasColumnType("int");

                    b.HasKey("TransactionId", "AmountModificationId");

                    b.HasIndex("AmountModificationId");

                    b.ToTable("TransactionAmountModifications");
                });

            modelBuilder.Entity("Domain.Entities.Transaction.TransactionCategory", b =>
                {
                    b.Property<int>("TransactionCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TransactionCategoryID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("TransactionCategoryId");

                    b.ToTable("TransactionCategories");
                });

            modelBuilder.Entity("Domain.Entities.Transaction.TransactionRecurrency", b =>
                {
                    b.Property<int>("TransactionRecurrencyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TransactionRecurrencyID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FrequencyType")
                        .HasColumnName("Frequency Type")
                        .HasColumnType("int");

                    b.Property<bool>("HasLimitations")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("TransactionId")
                        .HasColumnType("int");

                    b.HasKey("TransactionRecurrencyId");

                    b.HasIndex("TransactionId")
                        .IsUnique();

                    b.ToTable("TransactionRecurrencies");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Domain.Entities.Transaction.RecurrentTransactionCustomFrequency", b =>
                {
                    b.HasOne("Domain.Entities.Transaction.TransactionRecurrency", "TransactionRecurrency")
                        .WithOne("RecurrentTransactionCustomFrequency")
                        .HasForeignKey("Domain.Entities.Transaction.RecurrentTransactionCustomFrequency", "TransactionRecurrencyId")
                        .HasConstraintName("FK_RecurrentTransactionCustomFrequency_TransactionRecurrency")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Transaction.RecurrentTransactionInstallment", b =>
                {
                    b.HasOne("Domain.Entities.Transaction.TransactionRecurrency", "TransactionRecurrency")
                        .WithMany("RecurrentTransactionInstallments")
                        .HasForeignKey("TransactionRecurrencyId")
                        .HasConstraintName("FK_RecurrentTransactionInstallments_TransactionRecurrency")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Transaction.RecurrentTransactionLimitation", b =>
                {
                    b.HasOne("Domain.Entities.Transaction.TransactionRecurrency", "TransactionRecurrency")
                        .WithOne("RecurrentTransactionLimitation")
                        .HasForeignKey("Domain.Entities.Transaction.RecurrentTransactionLimitation", "TransactionRecurrencyId")
                        .HasConstraintName("FK_RecurrentTransactionLimitation_TransactionRecurrency")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Transaction.RecurrentTransactionSumAmountModification", b =>
                {
                    b.HasOne("Domain.Entities.Transaction.AmountModification", "AmountModification")
                        .WithMany("RecurrentTransactionSumAmountModifications")
                        .HasForeignKey("AmountModificationId")
                        .HasConstraintName("FK_RecurrentTransactionSumAmountModifications_AmountModifications")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Transaction.RecurrentTransactionLimitation", "RecurrentTransactionLimitation")
                        .WithMany("RecurrentTransactionSumAmountModifications")
                        .HasForeignKey("RecurrentTransactionLimitationId")
                        .HasConstraintName("FK_RecurrentTransactionSumAmountModifications_RecurrentTransactionLimitations")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Transaction.Transaction", b =>
                {
                    b.HasOne("Domain.Entities.Transaction.TransactionCategory", "Category")
                        .WithMany("Transactions")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_Transactions_Category")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.AppUser", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Transactions_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Transaction.TransactionAmountModification", b =>
                {
                    b.HasOne("Domain.Entities.Transaction.AmountModification", "AmountModification")
                        .WithMany("TransactionAmountModifications")
                        .HasForeignKey("AmountModificationId")
                        .HasConstraintName("FK_TransactionAmountModifications_AmountModifications")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Transaction.Transaction", "Transaction")
                        .WithMany("TransactionAmountModifications")
                        .HasForeignKey("TransactionId")
                        .HasConstraintName("FK_TransactionAmountModifications_Transactions")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Transaction.TransactionRecurrency", b =>
                {
                    b.HasOne("Domain.Entities.Transaction.Transaction", "Transaction")
                        .WithOne("TransactionRecurrency")
                        .HasForeignKey("Domain.Entities.Transaction.TransactionRecurrency", "TransactionId")
                        .HasConstraintName("FK_TransactionRecurrency_Transaction")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Domain.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Domain.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Domain.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}