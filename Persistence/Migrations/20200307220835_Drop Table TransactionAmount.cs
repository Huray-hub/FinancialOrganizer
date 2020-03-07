using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class DropTableTransactionAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AmountModifications_AmountModificationCategory",
                table: "AmountModifications");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionAmountModifications_TransactionAmounts",
                table: "TransactionAmountModifications");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionRecurrency_TransactionAmount",
                table: "TransactionRecurrencies");

            migrationBuilder.DropTable(
                name: "AmountModificationCategories");

            migrationBuilder.DropTable(
                name: "RecurrentTransactionInfo");

            migrationBuilder.DropTable(
                name: "TransactionAmounts");

            migrationBuilder.DropIndex(
                name: "IX_TransactionRecurrencies_TransactionAmountId",
                table: "TransactionRecurrencies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionAmountModifications",
                table: "TransactionAmountModifications");

            migrationBuilder.DropIndex(
                name: "IX_AmountModifications_AmountModificationCategoryID",
                table: "AmountModifications");

            migrationBuilder.DropColumn(
                name: "TransactionAmountId",
                table: "TransactionRecurrencies");

            migrationBuilder.DropColumn(
                name: "TransactionAmountID",
                table: "TransactionAmountModifications");

            migrationBuilder.DropColumn(
                name: "Recurrency Number",
                table: "RecurrentTransactionLimitations");

            migrationBuilder.DropColumn(
                name: "AmountModificationCategoryID",
                table: "AmountModifications");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Transactions",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Max Amount",
                table: "Transactions",
                type: "money",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionAmountId",
                table: "Transactions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Trigger Date",
                table: "Transactions",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TransactionId",
                table: "TransactionRecurrencies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TransactionID",
                table: "TransactionAmountModifications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Sum Installments",
                table: "RecurrentTransactionLimitations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "AmountModifications",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionAmountModifications",
                table: "TransactionAmountModifications",
                columns: new[] { "TransactionID", "AmountModificationID" });

            migrationBuilder.CreateTable(
                name: "RecurrentTransactionInstallments",
                columns: table => new
                {
                    RecurrentTransactionInstallmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentInstallment = table.Column<int>(name: "Current Installment", nullable: false),
                    InstallmentTriggerDate = table.Column<DateTime>(name: "Installment Trigger Date", nullable: false),
                    TransactionRecurrencyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecurrentTransactionInstallments", x => x.RecurrentTransactionInstallmentID);
                    table.ForeignKey(
                        name: "FK_RecurrentTransactionInstallments_TransactionRecurrency",
                        column: x => x.TransactionRecurrencyId,
                        principalTable: "TransactionRecurrencies",
                        principalColumn: "TransactionRecurrencyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionRecurrencies_TransactionId",
                table: "TransactionRecurrencies",
                column: "TransactionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecurrentTransactionInstallments_TransactionRecurrencyId",
                table: "RecurrentTransactionInstallments",
                column: "TransactionRecurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionAmountModifications_Transactions",
                table: "TransactionAmountModifications",
                column: "TransactionID",
                principalTable: "Transactions",
                principalColumn: "TransactionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionRecurrency_Transaction",
                table: "TransactionRecurrencies",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "TransactionID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionAmountModifications_Transactions",
                table: "TransactionAmountModifications");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionRecurrency_Transaction",
                table: "TransactionRecurrencies");

            migrationBuilder.DropTable(
                name: "RecurrentTransactionInstallments");

            migrationBuilder.DropIndex(
                name: "IX_TransactionRecurrencies_TransactionId",
                table: "TransactionRecurrencies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionAmountModifications",
                table: "TransactionAmountModifications");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Max Amount",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TransactionAmountId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Trigger Date",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "TransactionRecurrencies");

            migrationBuilder.DropColumn(
                name: "TransactionID",
                table: "TransactionAmountModifications");

            migrationBuilder.DropColumn(
                name: "Sum Installments",
                table: "RecurrentTransactionLimitations");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "AmountModifications");

            migrationBuilder.AddColumn<int>(
                name: "TransactionAmountId",
                table: "TransactionRecurrencies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TransactionAmountID",
                table: "TransactionAmountModifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Recurrency Number",
                table: "RecurrentTransactionLimitations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AmountModificationCategoryID",
                table: "AmountModifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionAmountModifications",
                table: "TransactionAmountModifications",
                columns: new[] { "TransactionAmountID", "AmountModificationID" });

            migrationBuilder.CreateTable(
                name: "AmountModificationCategories",
                columns: table => new
                {
                    AmountModificationCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmountModificationCategories", x => x.AmountModificationCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "RecurrentTransactionInfo",
                columns: table => new
                {
                    RecurrentTransactionInfoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentTransaction = table.Column<int>(type: "int", nullable: false),
                    CurrentTriggerDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionRecurrencyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecurrentTransactionInfo", x => x.RecurrentTransactionInfoID);
                    table.ForeignKey(
                        name: "FK_RecurrentTransactionInfo_TransactionRecurrency",
                        column: x => x.TransactionRecurrencyId,
                        principalTable: "TransactionRecurrencies",
                        principalColumn: "TransactionRecurrencyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionAmounts",
                columns: table => new
                {
                    TransactionAmountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    MaxAmount = table.Column<decimal>(name: "Max Amount", type: "money", nullable: true),
                    TransactionId = table.Column<int>(type: "int", nullable: false),
                    TriggerDate = table.Column<DateTime>(name: "Trigger Date", type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionAmounts", x => x.TransactionAmountID);
                    table.ForeignKey(
                        name: "FK_TransactionAmount_Transaction",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "TransactionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionRecurrencies_TransactionAmountId",
                table: "TransactionRecurrencies",
                column: "TransactionAmountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AmountModifications_AmountModificationCategoryID",
                table: "AmountModifications",
                column: "AmountModificationCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_RecurrentTransactionInfo_TransactionRecurrencyId",
                table: "RecurrentTransactionInfo",
                column: "TransactionRecurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionAmounts_TransactionId",
                table: "TransactionAmounts",
                column: "TransactionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AmountModifications_AmountModificationCategory",
                table: "AmountModifications",
                column: "AmountModificationCategoryID",
                principalTable: "AmountModificationCategories",
                principalColumn: "AmountModificationCategoryID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionAmountModifications_TransactionAmounts",
                table: "TransactionAmountModifications",
                column: "TransactionAmountID",
                principalTable: "TransactionAmounts",
                principalColumn: "TransactionAmountID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionRecurrency_TransactionAmount",
                table: "TransactionRecurrencies",
                column: "TransactionAmountId",
                principalTable: "TransactionAmounts",
                principalColumn: "TransactionAmountID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
