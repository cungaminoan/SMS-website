using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Migrations
{
    /// <inheritdoc />
    public partial class AddSoftwareVersionEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppMstSoftwareVersions",
                columns: table => new
                {
                    SoftwareCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    VersionCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    VersionContent = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    VersionStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppMstSoftwareVersions", x => new { x.SoftwareCode, x.VersionCode });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppMstSoftwareVersions");
        }
    }
}
