using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryVersta.Migrations
{
    public partial class Orders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderCity = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SenderAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipientCity = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    RecipientAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoWeight = table.Column<double>(type: "float", nullable: false),
                    PickupDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CargoWeight", "PickupDate", "RecipientAddress", "RecipientCity", "SenderAddress", "SenderCity" },
                values: new object[] { 1, 55.5, new DateTime(2021, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "ул. Белых 37", "Москва", "ул. Иванова 23", "Санкт-Петербург" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
