using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMSMS.CommonService.Migrations
{
    /// <inheritdoc />
    public partial class Added_SupplierMaster : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SupplierMasters",
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
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    DialCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ContactPhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SupplierStatus = table.Column<int>(type: "int", nullable: false),
                    Preffered = table.Column<bool>(type: "bit", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    SupplierServiceTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierMasters_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SupplierMasters_SupplierServiceTypes_SupplierServiceTypeId",
                        column: x => x.SupplierServiceTypeId,
                        principalTable: "SupplierServiceTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SupplierMasters_CountryId",
                table: "SupplierMasters",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierMasters_SupplierServiceTypeId",
                table: "SupplierMasters",
                column: "SupplierServiceTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupplierMasters");
        }
    }
}
