using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Web.DataAccess.Postgres.Migrations
{
    public partial class Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "AggregateId", "CreatedAt", "Data", "Type" },
                values: new object[,]
                {
                    { new Guid("4e80a596-02e7-4892-ac45-6cb8f01c0cf1"), new Guid("efa9a19c-a85b-41f5-af21-bb27776986aa"), new DateTime(2022, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "{\"Id\":\"efa9a19c-a85b-41f5-af21-bb27776986aa\",\"FirstName\":\"FirstName1\",\"LastName\":\"LastName1\"}", "UserCreatedEvent" },
                    { new Guid("88c44318-728e-4dbf-9e85-890a5367dbac"), new Guid("efa9a19c-a85b-41f5-af21-bb27776986ab"), new DateTime(2022, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "{\"Id\":\"efa9a19c-a85b-41f5-af21-bb27776986ab\",\"Name\":\"Product1\",\"Price\":1}", "ProductCreatedEvent" },
                    { new Guid("ebbfe1f8-8ff4-49c9-b49e-fd7754bc95e6"), new Guid("efa9a19c-a85b-41f5-af21-bb27776986ac"), new DateTime(2022, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "{\"Id\":\"efa9a19c-a85b-41f5-af21-bb27776986ac\",\"Name\":\"Product2\",\"Price\":20}", "ProductCreatedEvent" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("4e80a596-02e7-4892-ac45-6cb8f01c0cf1"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("88c44318-728e-4dbf-9e85-890a5367dbac"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("ebbfe1f8-8ff4-49c9-b49e-fd7754bc95e6"));
        }
    }
}
