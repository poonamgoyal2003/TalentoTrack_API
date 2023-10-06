using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TalentoTrack.Dao.Migrations
{
    /// <inheritdoc />
    public partial class AddVertualToBatchTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CourseReference",
                table: "tbl_Batch_details",
                newName: "Reference");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Reference",
                table: "tbl_Batch_details",
                newName: "CourseReference");
        }
    }
}
