using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class adfsd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bankDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    number = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bank_details", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "credentials",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    password = table.Column<string>(type: "text", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modified_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_credentials", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "deductible_cost",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<decimal>(type: "numeric", nullable: false),
                    row_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modified_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_deductible_cost", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "insuranceCodes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    code = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modified_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_insurance_codes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "jobPositions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modified_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_job_positions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    status = table.Column<string>(type: "text", nullable: false),
                    contractor_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modified_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    firstname = table.Column<string>(type: "text", nullable: false),
                    lastname = table.Column<string>(type: "text", nullable: false),
                    second_name = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: true),
                    identity_number = table.Column<string>(type: "text", nullable: true),
                    date_of_birth = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    place_of_birth = table.Column<string>(type: "text", nullable: true),
                    sex = table.Column<string>(type: "text", nullable: true),
                    is_student = table.Column<bool>(type: "boolean", nullable: false),
                    credential_id = table.Column<int>(type: "integer", nullable: false),
                    job_position_id = table.Column<int>(type: "integer", nullable: true),
                    refresh_token = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modified_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_users_credentials_credential_temp_id1",
                        column: x => x.credential_id,
                        principalTable: "credentials",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_users_job_positions_job_position_temp_id",
                        column: x => x.job_position_id,
                        principalTable: "jobPositions",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "absences",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    start_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    disease_code = table.Column<string>(type: "text", nullable: true),
                    series = table.Column<string>(type: "text", nullable: false),
                    number = table.Column<string>(type: "text", nullable: false),
                    release_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    delivery_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modified_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_absences", x => x.id);
                    table.ForeignKey(
                        name: "fk_absences_users_user_temp_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cards",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number = table.Column<string>(type: "text", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modified_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cards", x => x.id);
                    table.ForeignKey(
                        name: "fk_cards_users_user_temp_id1",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contracts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    status = table.Column<int>(type: "integer", nullable: false),
                    salary_with_tax = table.Column<decimal>(type: "numeric", nullable: false),
                    salary_without_tax = table.Column<decimal>(type: "numeric", nullable: false),
                    working_hours1 = table.Column<int>(type: "integer", nullable: false),
                    working_hours2 = table.Column<int>(type: "integer", nullable: false),
                    signed_on_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    start_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    job_fund = table.Column<bool>(type: "boolean", nullable: false),
                    pension_fund = table.Column<bool>(type: "boolean", nullable: false),
                    voluntary_contribution = table.Column<bool>(type: "boolean", nullable: false),
                    profitable_fund = table.Column<bool>(type: "boolean", nullable: false),
                    fgsp = table.Column<bool>(type: "boolean", nullable: false),
                    pit_exemption = table.Column<bool>(type: "boolean", nullable: false),
                    contract_type = table.Column<int>(type: "integer", nullable: false),
                    insurance_code_id = table.Column<int>(type: "integer", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    job_position_id = table.Column<int>(type: "integer", nullable: true),
                    tax_relief = table.Column<bool>(type: "boolean", nullable: false),
                    deductible_cost_id = table.Column<int>(type: "integer", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modified_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_contracts", x => x.id);
                    table.ForeignKey(
                        name: "fk_contracts_users_user_temp_id2",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "holidayLimits",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    current = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    available_days = table.Column<int>(type: "integer", nullable: false),
                    used_days = table.Column<int>(type: "integer", nullable: false),
                    merged_days = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modified_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_holiday_limits", x => x.id);
                    table.ForeignKey(
                        name: "fk_holiday_limits_users_user_temp_id3",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "jobHistories",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    company_name = table.Column<string>(type: "text", nullable: false),
                    position = table.Column<string>(type: "text", nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modified_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_job_histories", x => x.id);
                    table.ForeignKey(
                        name: "fk_job_histories_users_user_temp_id4",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    street = table.Column<string>(type: "text", nullable: false),
                    house_no = table.Column<string>(type: "text", nullable: false),
                    apartment_no = table.Column<string>(type: "text", nullable: false),
                    postal_code = table.Column<string>(type: "text", nullable: false),
                    city = table.Column<string>(type: "text", nullable: false),
                    country = table.Column<string>(type: "text", nullable: false),
                    is_private = table.Column<bool>(type: "boolean", nullable: false),
                    is_company = table.Column<bool>(type: "boolean", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_locations", x => x.id);
                    table.ForeignKey(
                        name: "fk_locations_users_user_temp_id5",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "schedules",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    start_work_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    end_work_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modified_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_schedules", x => x.id);
                    table.ForeignKey(
                        name: "fk_schedules_users_user_temp_id9",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "schoolHistories",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    school_name = table.Column<string>(type: "text", nullable: false),
                    degree = table.Column<int>(type: "integer", nullable: false),
                    specialization = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modified_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_school_histories", x => x.id);
                    table.ForeignKey(
                        name: "fk_school_histories_users_user_temp_id7",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "absenceStatuses",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    status = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    absence_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_absence_statuses", x => x.id);
                    table.ForeignKey(
                        name: "fk_absence_statuses_absences_absence_id",
                        column: x => x.absence_id,
                        principalTable: "absences",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permissions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    code = table.Column<int>(type: "integer", nullable: false),
                    card_id = table.Column<int>(type: "integer", nullable: true),
                    credential_id = table.Column<int>(type: "integer", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modified_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_permissions", x => x.id);
                    table.ForeignKey(
                        name: "fk_permissions_cards_card_temp_id",
                        column: x => x.card_id,
                        principalTable: "cards",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_permissions_credentials_credential_temp_id",
                        column: x => x.credential_id,
                        principalTable: "credentials",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "workingTimes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    start_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    start_work_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    end_work_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    card_id = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modified_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_working_times", x => x.id);
                    table.ForeignKey(
                        name: "fk_working_times_cards_card_id1",
                        column: x => x.card_id,
                        principalTable: "cards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contractChanges",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    contract_id = table.Column<int>(type: "integer", nullable: false),
                    contract_change_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modified_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_contract_changes", x => x.id);
                    table.ForeignKey(
                        name: "fk_contract_changes_contracts_contract_changed_temp_id2",
                        column: x => x.contract_change_id,
                        principalTable: "contracts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_contract_changes_contracts_contract_temp_id1",
                        column: x => x.contract_id,
                        principalTable: "contracts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_contracts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    contract_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modified_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_contracts", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_contracts_contracts_contract_temp_id",
                        column: x => x.contract_id,
                        principalTable: "contracts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_contracts_users_user_temp_id8",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contractors",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_name = table.Column<string>(type: "text", nullable: false),
                    short_name = table.Column<string>(type: "text", nullable: false),
                    representative = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    nip = table.Column<string>(type: "text", nullable: false),
                    locationid = table.Column<int>(type: "integer", nullable: false),
                    bank_detailsid = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modified_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_contractors", x => x.id);
                    table.ForeignKey(
                        name: "fk_contractors_bank_details_bank_details_temp_id",
                        column: x => x.bank_detailsid,
                        principalTable: "bankDetails",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_contractors_locations_location_temp_id",
                        column: x => x.locationid,
                        principalTable: "locations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "stocks",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    locationid = table.Column<int>(type: "integer", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modified_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stocks", x => x.id);
                    table.ForeignKey(
                        name: "fk_stocks_locations_location_temp_id1",
                        column: x => x.locationid,
                        principalTable: "locations",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "user_permissions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    permission_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modified_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_permissions", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_permissions_permissions_permission_temp_id",
                        column: x => x.permission_id,
                        principalTable: "permissions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_permissions_users_user_temp_id6",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "articles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    code = table.Column<string>(type: "text", nullable: false),
                    gtin = table.Column<string>(type: "text", nullable: false),
                    measure_unit = table.Column<string>(type: "text", nullable: false),
                    pkwiu = table.Column<string>(type: "text", nullable: false),
                    buy_price_without_tax = table.Column<decimal>(type: "numeric", nullable: false),
                    buy_price_with_tax = table.Column<decimal>(type: "numeric", nullable: false),
                    sell_price_without_tax = table.Column<decimal>(type: "numeric", nullable: false),
                    sell_price_with_tax = table.Column<decimal>(type: "numeric", nullable: false),
                    tax_id = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    order_id = table.Column<int>(type: "integer", nullable: true),
                    stock_id = table.Column<int>(type: "integer", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modified_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_articles", x => x.id);
                    table.ForeignKey(
                        name: "fk_articles_order_order_temp_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_articles_stocks_stock_temp_id",
                        column: x => x.stock_id,
                        principalTable: "stocks",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_absences_user_id",
                table: "absences",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_absence_statuses_absence_id",
                table: "absenceStatuses",
                column: "absence_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_articles_order_id",
                table: "articles",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "ix_articles_stock_id",
                table: "articles",
                column: "stock_id");

            migrationBuilder.CreateIndex(
                name: "ix_cards_user_id",
                table: "cards",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_contract_changes_contract_change_id",
                table: "contractChanges",
                column: "contract_change_id");

            migrationBuilder.CreateIndex(
                name: "ix_contract_changes_contract_id",
                table: "contractChanges",
                column: "contract_id");

            migrationBuilder.CreateIndex(
                name: "ix_contractors_bank_detailsid",
                table: "contractors",
                column: "bank_detailsid");

            migrationBuilder.CreateIndex(
                name: "ix_contractors_locationid",
                table: "contractors",
                column: "locationid");

            migrationBuilder.CreateIndex(
                name: "ix_contracts_user_id",
                table: "contracts",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_holiday_limits_user_id",
                table: "holidayLimits",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_job_histories_user_id",
                table: "jobHistories",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_locations_user_id",
                table: "locations",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_permissions_card_id",
                table: "permissions",
                column: "card_id");

            migrationBuilder.CreateIndex(
                name: "ix_permissions_credential_id",
                table: "permissions",
                column: "credential_id");

            migrationBuilder.CreateIndex(
                name: "ix_schedules_user_id",
                table: "schedules",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_school_histories_user_id",
                table: "schoolHistories",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_stocks_locationid",
                table: "stocks",
                column: "locationid");

            migrationBuilder.CreateIndex(
                name: "ix_user_contracts_contract_id",
                table: "user_contracts",
                column: "contract_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_contracts_user_id",
                table: "user_contracts",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_permissions_permission_id",
                table: "user_permissions",
                column: "permission_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_permissions_user_id",
                table: "user_permissions",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_credential_id",
                table: "users",
                column: "credential_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_job_position_id",
                table: "users",
                column: "job_position_id");

            migrationBuilder.CreateIndex(
                name: "ix_working_times_card_id",
                table: "workingTimes",
                column: "card_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "absenceStatuses");

            migrationBuilder.DropTable(
                name: "articles");

            migrationBuilder.DropTable(
                name: "contractChanges");

            migrationBuilder.DropTable(
                name: "contractors");

            migrationBuilder.DropTable(
                name: "deductible_cost");

            migrationBuilder.DropTable(
                name: "holidayLimits");

            migrationBuilder.DropTable(
                name: "insuranceCodes");

            migrationBuilder.DropTable(
                name: "jobHistories");

            migrationBuilder.DropTable(
                name: "schedules");

            migrationBuilder.DropTable(
                name: "schoolHistories");

            migrationBuilder.DropTable(
                name: "user_contracts");

            migrationBuilder.DropTable(
                name: "user_permissions");

            migrationBuilder.DropTable(
                name: "workingTimes");

            migrationBuilder.DropTable(
                name: "absences");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "stocks");

            migrationBuilder.DropTable(
                name: "bankDetails");

            migrationBuilder.DropTable(
                name: "contracts");

            migrationBuilder.DropTable(
                name: "permissions");

            migrationBuilder.DropTable(
                name: "locations");

            migrationBuilder.DropTable(
                name: "cards");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "credentials");

            migrationBuilder.DropTable(
                name: "jobPositions");
        }
    }
}
