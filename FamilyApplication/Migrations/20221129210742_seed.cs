using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyApplication.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("6fadd7c7-d24a-4e43-a411-06b9844c6c9f"), "Familie" },
                    { new Guid("7a2a8355-d33a-4267-9da6-2d4877920d07"), "Sabina" },
                    { new Guid("a561cd97-3b2e-40c1-b9c2-e7aea68460e7"), "Darius" },
                    { new Guid("dbb27d61-f494-4e80-82ad-0186e35c2515"), "Abby" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("6fadd7c7-d24a-4e43-a411-06b9844c6c9f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("7a2a8355-d33a-4267-9da6-2d4877920d07"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("a561cd97-3b2e-40c1-b9c2-e7aea68460e7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("dbb27d61-f494-4e80-82ad-0186e35c2515"));
        }
    }
}
