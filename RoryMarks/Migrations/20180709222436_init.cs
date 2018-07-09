using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RoryMarks.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookmarks",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bookmark = table.Column<string>(nullable: true),
                    TopicID = table.Column<string>(nullable: true),
                    TopicID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookmarks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bookmarks_Topic_TopicID1",
                        column: x => x.TopicID1,
                        principalTable: "Topic",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookmarks_TopicID1",
                table: "Bookmarks",
                column: "TopicID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookmarks");
        }
    }
}
