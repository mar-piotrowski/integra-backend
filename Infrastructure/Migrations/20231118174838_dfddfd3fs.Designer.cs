﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20231118174838_dfddfd3fs")]
    partial class dfddfd3fs
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Absence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("delivery_date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("DiseaseCode")
                        .HasColumnType("text")
                        .HasColumnName("disease_code");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("end_date");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modified_date");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("number");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("release_date");

                    b.Property<string>("Series")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("series");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_date");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_absences");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_absences_user_id");

                    b.ToTable("absences", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("code");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Gtin")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("gtin");

                    b.Property<string>("MeasureUnit")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("measure_unit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modified_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int?>("OrderId")
                        .HasColumnType("integer")
                        .HasColumnName("order_id");

                    b.Property<string>("Pkwiu")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("pkwiu");

                    b.Property<int>("StockId")
                        .HasColumnType("integer")
                        .HasColumnName("stock_id");

                    b.HasKey("Id")
                        .HasName("pk_articles");

                    b.HasIndex("OrderId")
                        .HasDatabaseName("ix_articles_order_id");

                    b.HasIndex("StockId")
                        .HasDatabaseName("ix_articles_stock_id");

                    b.ToTable("articles", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ContractType")
                        .HasColumnType("integer")
                        .HasColumnName("contract_type");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("end_date");

                    b.Property<bool>("Fgsp")
                        .HasColumnType("boolean")
                        .HasColumnName("fgsp");

                    b.Property<int>("InsuranceCodeId")
                        .HasColumnType("integer")
                        .HasColumnName("insurance_code_id");

                    b.Property<bool>("JobFund")
                        .HasColumnType("boolean")
                        .HasColumnName("job_fund");

                    b.Property<int>("JobPositionId")
                        .HasColumnType("integer")
                        .HasColumnName("job_position_id");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modified_date");

                    b.Property<bool>("PitExemption")
                        .HasColumnType("boolean")
                        .HasColumnName("pit_exemption");

                    b.Property<decimal>("Salary")
                        .HasColumnType("numeric")
                        .HasColumnName("salary");

                    b.Property<DateTime>("SignedOnDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("signed_on_date");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_date");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_contracts");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_contracts_user_id");

                    b.ToTable("contracts", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Contractor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BankDetailsid")
                        .HasColumnType("integer")
                        .HasColumnName("bank_detailsid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("full_name");

                    b.Property<int>("Locationid")
                        .HasColumnType("integer")
                        .HasColumnName("locationid");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modified_date");

                    b.Property<string>("Nip")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nip");

                    b.Property<string>("Representative")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("representative");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("short_name");

                    b.HasKey("Id")
                        .HasName("pk_contractors");

                    b.HasIndex("BankDetailsid")
                        .HasDatabaseName("ix_contractors_bank_detailsid");

                    b.HasIndex("Locationid")
                        .HasDatabaseName("ix_contractors_locationid");

                    b.ToTable("contractors", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Credential", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modified_date");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<int>("Permission")
                        .HasColumnType("integer")
                        .HasColumnName("permission");

                    b.HasKey("Id")
                        .HasName("pk_credentials");

                    b.ToTable("credentials", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.InsuranceCode", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("code");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modified_date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_insurance_codes");

                    b.ToTable("insuranceCodes", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.JobPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modified_date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_job_positions");

                    b.ToTable("jobPositions", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ContractorId")
                        .HasColumnType("integer")
                        .HasColumnName("contractor_id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modified_date");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.HasKey("Id")
                        .HasName("pk_orders");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<int?>("Locationid")
                        .HasColumnType("integer")
                        .HasColumnName("locationid");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modified_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_stocks");

                    b.HasIndex("Locationid")
                        .HasDatabaseName("ix_stocks_locationid");

                    b.ToTable("stocks", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<int>("CredentialId")
                        .HasColumnType("integer")
                        .HasColumnName("credential_id");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("firstname");

                    b.Property<string>("IdentityNumber")
                        .HasColumnType("text")
                        .HasColumnName("identity_number");

                    b.Property<bool>("IsStudent")
                        .HasColumnType("boolean")
                        .HasColumnName("is_student");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("lastname");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modified_date");

                    b.Property<string>("Phone")
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.Property<string>("PlaceOfBirth")
                        .HasColumnType("text")
                        .HasColumnName("place_of_birth");

                    b.Property<string>("SecondName")
                        .HasColumnType("text")
                        .HasColumnName("second_name");

                    b.Property<string>("Sex")
                        .HasColumnType("text")
                        .HasColumnName("sex");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("CredentialId")
                        .HasDatabaseName("ix_users_credential_id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Domain.ValueObjects.AbsenceStatus", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int>("AbsenceId")
                        .HasColumnType("integer")
                        .HasColumnName("absence_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.HasKey("id")
                        .HasName("pk_absence_statuses");

                    b.HasIndex("AbsenceId")
                        .IsUnique()
                        .HasDatabaseName("ix_absence_statuses_absence_id");

                    b.ToTable("absenceStatuses", (string)null);
                });

            modelBuilder.Entity("Domain.ValueObjects.Ids.BankDetails", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("number");

                    b.HasKey("id")
                        .HasName("pk_bank_details");

                    b.ToTable("bankDetails", (string)null);
                });

            modelBuilder.Entity("Domain.ValueObjects.Location", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("ApartmentNo")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("apartment_no");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("country");

                    b.Property<string>("HouseNo")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("house_no");

                    b.Property<bool>("IsCompany")
                        .HasColumnType("boolean")
                        .HasColumnName("is_company");

                    b.Property<bool>("IsPrivate")
                        .HasColumnType("boolean")
                        .HasColumnName("is_private");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("postal_code");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("street");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("id")
                        .HasName("pk_locations");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_locations_user_id");

                    b.ToTable("locations", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Absence", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("Absences")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_absences_users_user_temp_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Article", b =>
                {
                    b.HasOne("Domain.Entities.Order", null)
                        .WithMany("Articles")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("fk_articles_order_order_temp_id");

                    b.HasOne("Domain.Entities.Stock", null)
                        .WithMany("Articles")
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_articles_stocks_stock_temp_id");
                });

            modelBuilder.Entity("Domain.Entities.Contract", b =>
                {
                    b.HasOne("Domain.Entities.User", null)
                        .WithMany("Contracts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_contracts_users_user_temp_id1");
                });

            modelBuilder.Entity("Domain.Entities.Contractor", b =>
                {
                    b.HasOne("Domain.ValueObjects.Ids.BankDetails", "BankDetails")
                        .WithMany()
                        .HasForeignKey("BankDetailsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_contractors_bank_details_bank_details_temp_id");

                    b.HasOne("Domain.ValueObjects.Location", "Location")
                        .WithMany()
                        .HasForeignKey("Locationid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_contractors_locations_location_temp_id");

                    b.Navigation("BankDetails");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Domain.Entities.Stock", b =>
                {
                    b.HasOne("Domain.ValueObjects.Location", "Location")
                        .WithMany()
                        .HasForeignKey("Locationid")
                        .HasConstraintName("fk_stocks_locations_location_temp_id1");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.HasOne("Domain.Entities.Credential", "Credential")
                        .WithMany()
                        .HasForeignKey("CredentialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_users_credentials_credential_temp_id");

                    b.Navigation("Credential");
                });

            modelBuilder.Entity("Domain.ValueObjects.AbsenceStatus", b =>
                {
                    b.HasOne("Domain.Entities.Absence", null)
                        .WithOne("Status")
                        .HasForeignKey("Domain.ValueObjects.AbsenceStatus", "AbsenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_absence_statuses_absences_absence_id");
                });

            modelBuilder.Entity("Domain.ValueObjects.Location", b =>
                {
                    b.HasOne("Domain.Entities.User", null)
                        .WithMany("Locations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_locations_users_user_temp_id2");
                });

            modelBuilder.Entity("Domain.Entities.Absence", b =>
                {
                    b.Navigation("Status")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Order", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("Domain.Entities.Stock", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("Absences");

                    b.Navigation("Contracts");

                    b.Navigation("Locations");
                });
#pragma warning restore 612, 618
        }
    }
}
