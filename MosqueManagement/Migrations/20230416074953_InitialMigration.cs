﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MosqueManagement.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    donationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    donationSuccess = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    donationAmount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donations", x => x.donationId);
                });

            migrationBuilder.CreateTable(
                name: "Markets",
                columns: table => new
                {
                    marketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    marketName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    marketDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    marketContact = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markets", x => x.marketId);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    serviceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    serviceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    serviceDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    servicePrice = table.Column<double>(type: "float", nullable: false),
                    serviceEquipments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    serviceCategory = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.serviceId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "HumanResources",
                columns: table => new
                {
                    positionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    positionTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    positionDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    staffName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    staffContact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    serviceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HumanResources", x => x.positionId);
                    table.ForeignKey(
                        name: "FK_HumanResources_Services_serviceId",
                        column: x => x.serviceId,
                        principalTable: "Services",
                        principalColumn: "serviceId");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    paymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    paymentSuccess = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    amount = table.Column<double>(type: "float", nullable: false),
                    Userid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.paymentId);
                    table.ForeignKey(
                        name: "FK_Payments_Users_Userid",
                        column: x => x.Userid,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    formId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    equipment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    approval = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    approvalMonth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    approvalYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    feedback = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    package = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Userid = table.Column<int>(type: "int", nullable: true),
                    paymentId = table.Column<int>(type: "int", nullable: true),
                    serviceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.formId);
                    table.ForeignKey(
                        name: "FK_Classes_Payments_paymentId",
                        column: x => x.paymentId,
                        principalTable: "Payments",
                        principalColumn: "paymentId");
                    table.ForeignKey(
                        name: "FK_Classes_Services_serviceId",
                        column: x => x.serviceId,
                        principalTable: "Services",
                        principalColumn: "serviceId");
                    table.ForeignKey(
                        name: "FK_Classes_Users_Userid",
                        column: x => x.Userid,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    formId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    eventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eventDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    startDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    endDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    approval = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    approvalMonth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    approvalYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    feedback = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    package = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Userid = table.Column<int>(type: "int", nullable: true),
                    paymentId = table.Column<int>(type: "int", nullable: true),
                    serviceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.formId);
                    table.ForeignKey(
                        name: "FK_Rentals_Payments_paymentId",
                        column: x => x.paymentId,
                        principalTable: "Payments",
                        principalColumn: "paymentId");
                    table.ForeignKey(
                        name: "FK_Rentals_Services_serviceId",
                        column: x => x.serviceId,
                        principalTable: "Services",
                        principalColumn: "serviceId");
                    table.ForeignKey(
                        name: "FK_Rentals_Users_Userid",
                        column: x => x.Userid,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Socials",
                columns: table => new
                {
                    formId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    eventDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eventTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    approval = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    approvalMonth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    approvalYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    feedback = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    package = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Userid = table.Column<int>(type: "int", nullable: true),
                    paymentId = table.Column<int>(type: "int", nullable: true),
                    serviceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socials", x => x.formId);
                    table.ForeignKey(
                        name: "FK_Socials_Payments_paymentId",
                        column: x => x.paymentId,
                        principalTable: "Payments",
                        principalColumn: "paymentId");
                    table.ForeignKey(
                        name: "FK_Socials_Services_serviceId",
                        column: x => x.serviceId,
                        principalTable: "Services",
                        principalColumn: "serviceId");
                    table.ForeignKey(
                        name: "FK_Socials_Users_Userid",
                        column: x => x.Userid,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    scheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    occupied = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassformId = table.Column<int>(type: "int", nullable: true),
                    RentalformId = table.Column<int>(type: "int", nullable: true),
                    SocialformId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.scheduleId);
                    table.ForeignKey(
                        name: "FK_Schedules_Classes_ClassformId",
                        column: x => x.ClassformId,
                        principalTable: "Classes",
                        principalColumn: "formId");
                    table.ForeignKey(
                        name: "FK_Schedules_Rentals_RentalformId",
                        column: x => x.RentalformId,
                        principalTable: "Rentals",
                        principalColumn: "formId");
                    table.ForeignKey(
                        name: "FK_Schedules_Socials_SocialformId",
                        column: x => x.SocialformId,
                        principalTable: "Socials",
                        principalColumn: "formId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_paymentId",
                table: "Classes",
                column: "paymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_serviceId",
                table: "Classes",
                column: "serviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_Userid",
                table: "Classes",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_HumanResources_serviceId",
                table: "HumanResources",
                column: "serviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Userid",
                table: "Payments",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_paymentId",
                table: "Rentals",
                column: "paymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_serviceId",
                table: "Rentals",
                column: "serviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_Userid",
                table: "Rentals",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ClassformId",
                table: "Schedules",
                column: "ClassformId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_RentalformId",
                table: "Schedules",
                column: "RentalformId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_SocialformId",
                table: "Schedules",
                column: "SocialformId");

            migrationBuilder.CreateIndex(
                name: "IX_Socials_paymentId",
                table: "Socials",
                column: "paymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Socials_serviceId",
                table: "Socials",
                column: "serviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Socials_Userid",
                table: "Socials",
                column: "Userid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donations");

            migrationBuilder.DropTable(
                name: "HumanResources");

            migrationBuilder.DropTable(
                name: "Markets");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "Socials");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
