using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoWebAPIApp.Migrations
{
    public partial class AddTblType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeID",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_TypeID",
                table: "Product",
                column: "TypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Type_TypeID",
                table: "Product",
                column: "TypeID",
                principalTable: "Type",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Type_TypeID",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.DropIndex(
                name: "IX_Product_TypeID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "TypeID",
                table: "Product");
        }
    }
}
