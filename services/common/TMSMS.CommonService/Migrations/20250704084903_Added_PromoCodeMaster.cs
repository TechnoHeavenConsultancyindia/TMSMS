using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMSMS.CommonService.Migrations
{
    /// <inheritdoc />
    public partial class Added_PromoCodeMaster : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PromoCodeMasters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PromoCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ServiceType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DiscountType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DiscountValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateEffectiveFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEffectiveTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaxUsageLimit = table.Column<int>(type: "int", nullable: true),
                    MaxUsagePerUser = table.Column<int>(type: "int", nullable: true),
                    CustomerType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MinBookingAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserGroup = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MinNoOfNights = table.Column<int>(type: "int", nullable: false),
                    MinNoOfPax = table.Column<int>(type: "int", nullable: false),
                    EarlyBirdDays = table.Column<int>(type: "int", nullable: false),
                    ValidTimeFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidTimeTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Stackable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromoCodeMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PromoCodeMasterCity",
                columns: table => new
                {
                    PromoCodeMasterId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromoCodeMasterCity", x => new { x.PromoCodeMasterId, x.CityId });
                    table.ForeignKey(
                        name: "FK_PromoCodeMasterCity_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PromoCodeMasterCity_PromoCodeMasters_PromoCodeMasterId",
                        column: x => x.PromoCodeMasterId,
                        principalTable: "PromoCodeMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PromoCodeMasterCountry",
                columns: table => new
                {
                    PromoCodeMasterId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromoCodeMasterCountry", x => new { x.PromoCodeMasterId, x.CountryId });
                    table.ForeignKey(
                        name: "FK_PromoCodeMasterCountry_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PromoCodeMasterCountry_PromoCodeMasters_PromoCodeMasterId",
                        column: x => x.PromoCodeMasterId,
                        principalTable: "PromoCodeMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PromoCodeMasterCity_CityId",
                table: "PromoCodeMasterCity",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_PromoCodeMasterCity_PromoCodeMasterId_CityId",
                table: "PromoCodeMasterCity",
                columns: new[] { "PromoCodeMasterId", "CityId" });

            migrationBuilder.CreateIndex(
                name: "IX_PromoCodeMasterCountry_CountryId",
                table: "PromoCodeMasterCountry",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_PromoCodeMasterCountry_PromoCodeMasterId_CountryId",
                table: "PromoCodeMasterCountry",
                columns: new[] { "PromoCodeMasterId", "CountryId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PromoCodeMasterCity");

            migrationBuilder.DropTable(
                name: "PromoCodeMasterCountry");

            migrationBuilder.DropTable(
                name: "PromoCodeMasters");
        }
    }
}
