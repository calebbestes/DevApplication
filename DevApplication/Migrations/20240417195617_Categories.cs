using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevApplication.Migrations
{
    /// <inheritdoc />
    public partial class Categories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CategoryID",
                table: "Contacts",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Category_CategoryID",
                table: "Contacts",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Category_CategoryID",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_CategoryID",
                table: "Contacts");
        }
    }
}
