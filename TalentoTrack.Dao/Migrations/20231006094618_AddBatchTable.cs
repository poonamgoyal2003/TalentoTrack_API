using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TalentoTrack.Dao.Migrations
{
    /// <inheritdoc />
    public partial class AddBatchTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "tbl_Course_details");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_Course_details",
                table: "tbl_Course_details",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "tbl_Batch_details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CourseReference = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Batch_details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Batch_details_tbl_Course_details_CourseId",
                        column: x => x.CourseId,
                        principalTable: "tbl_Course_details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Batch_details_CourseId",
                table: "tbl_Batch_details",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Batch_details");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_Course_details",
                table: "tbl_Course_details");

            migrationBuilder.RenameTable(
                name: "tbl_Course_details",
                newName: "Course");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "Id");
        }
    }
}
