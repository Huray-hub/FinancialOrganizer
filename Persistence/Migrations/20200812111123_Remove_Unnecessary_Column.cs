using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Persistence.Migrations
{
    public partial class Remove_Unnecessary_Column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionAmountId",
                table: "Transactions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Transactions",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 12, 14, 11, 23, 677, DateTimeKind.Local).AddTicks(5156),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2020, 6, 30, 0, 44, 15, 616, DateTimeKind.Local).AddTicks(3493));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Transactions",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 30, 0, 44, 15, 616, DateTimeKind.Local).AddTicks(3493),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2020, 8, 12, 14, 11, 23, 677, DateTimeKind.Local).AddTicks(5156));

            migrationBuilder.AddColumn<int>(
                name: "TransactionAmountId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
