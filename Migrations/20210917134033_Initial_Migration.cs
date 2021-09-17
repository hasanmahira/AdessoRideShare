using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AdessoRideShare.Migrations
{
    public partial class Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Longitude = table.Column<int>(type: "integer", nullable: false),
                    Latitude = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RidePlans",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FromId = table.Column<int>(type: "integer", nullable: false),
                    WhereId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    NumberOfSeats = table.Column<int>(type: "integer", nullable: false),
                    IsPublished = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RidePlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RidePlans_Cities_FromId",
                        column: x => x.FromId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RidePlans_Cities_WhereId",
                        column: x => x.WhereId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RidePossibleRoutes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RidePlanId = table.Column<long>(type: "bigint", nullable: false),
                    PassingCityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RidePossibleRoutes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RidePossibleRoutes_Cities_PassingCityId",
                        column: x => x.PassingCityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RidePossibleRoutes_RidePlans_RidePlanId",
                        column: x => x.RidePlanId,
                        principalTable: "RidePlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SharedRides",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RidePlanId = table.Column<long>(type: "bigint", nullable: false),
                    PassengerName = table.Column<string>(type: "text", nullable: false),
                    PassengerSurName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SharedRides", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SharedRides_RidePlans_RidePlanId",
                        column: x => x.RidePlanId,
                        principalTable: "RidePlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RidePlans_FromId",
                table: "RidePlans",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_RidePlans_WhereId",
                table: "RidePlans",
                column: "WhereId");

            migrationBuilder.CreateIndex(
                name: "IX_RidePossibleRoutes_PassingCityId",
                table: "RidePossibleRoutes",
                column: "PassingCityId");

            migrationBuilder.CreateIndex(
                name: "IX_RidePossibleRoutes_RidePlanId",
                table: "RidePossibleRoutes",
                column: "RidePlanId");

            migrationBuilder.CreateIndex(
                name: "IX_SharedRides_RidePlanId",
                table: "SharedRides",
                column: "RidePlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RidePossibleRoutes");

            migrationBuilder.DropTable(
                name: "SharedRides");

            migrationBuilder.DropTable(
                name: "RidePlans");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
