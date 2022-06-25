using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Web.DataAccess.Postgres.Migrations
{
    public partial class Index : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderItem_ProductId",
                table: "OrderItem");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductId_OrderId",
                table: "OrderItem",
                columns: new[] { "ProductId", "OrderId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderItem_ProductId_OrderId",
                table: "OrderItem");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductId",
                table: "OrderItem",
                column: "ProductId");
        }
    }
}
