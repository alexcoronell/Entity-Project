using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projectef.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("108e7a15-0cc3-456d-82c3-71e2c0d0b5c6"), null, "Personal Tasks", 50 },
                    { new Guid("8e6fd9a7-1fee-4b87-b724-b2c8b5aa75a0"), null, "Pending Tasks", 20 }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "CategoryId", "DateCreated", "Description", "PriorityTask", "Title" },
                values: new object[,]
                {
                    { new Guid("26ddde96-39d7-4598-a401-80ed2ea504ce"), new Guid("8e6fd9a7-1fee-4b87-b724-b2c8b5aa75a0"), new DateTime(2024, 8, 1, 12, 18, 15, 740, DateTimeKind.Local).AddTicks(9947), null, 1, "Payment Public Services" },
                    { new Guid("6478568f-4f18-4001-8035-98c522b2f03a"), new Guid("108e7a15-0cc3-456d-82c3-71e2c0d0b5c6"), new DateTime(2024, 8, 1, 12, 18, 15, 740, DateTimeKind.Local).AddTicks(9978), null, 0, "Complete movie in Netflix" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("26ddde96-39d7-4598-a401-80ed2ea504ce"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("6478568f-4f18-4001-8035-98c522b2f03a"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("108e7a15-0cc3-456d-82c3-71e2c0d0b5c6"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("8e6fd9a7-1fee-4b87-b724-b2c8b5aa75a0"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
