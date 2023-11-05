using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Migrations
{
    /// <inheritdoc />
    public partial class AddVersionLocationtoEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VersionCode",
                table: "AppMstSoftwareVersions",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.CreateTable(
                name: "AppMstVersionLocation",
                columns: table => new
                {
                    SoftwareCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    VersionCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Factorycode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LinelCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ProcessCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    FromDate = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    ToDate = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    SoftwareStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppMstVersionLocation", x => new { x.SoftwareCode, x.VersionCode });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppMstVersionLocation");

            migrationBuilder.AlterColumn<string>(
                name: "VersionCode",
                table: "AppMstSoftwareVersions",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);
        }
    }
}
