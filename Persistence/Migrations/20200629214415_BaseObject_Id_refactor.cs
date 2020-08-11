using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class BaseObject_Id_refactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecurrentTransactionCustomFrequency_TransactionRecurrency",
                table: "RecurrentTransactionCustomFrequencies");

            migrationBuilder.DropForeignKey(
                name: "FK_RecurrentTransactionInstallments_TransactionRecurrency",
                table: "RecurrentTransactionInstallments");

            migrationBuilder.DropForeignKey(
                name: "FK_RecurrentTransactionLimitation_TransactionRecurrency",
                table: "RecurrentTransactionLimitations");

            migrationBuilder.DropForeignKey(
                name: "FK_RecurrentTransactionSumAmountModifications_AmountModifications",
                table: "RecurrentTransactionSumAmountModifications");

            migrationBuilder.DropForeignKey(
                name: "FK_RecurrentTransactionSumAmountModifications_RecurrentTransactionLimitations",
                table: "RecurrentTransactionSumAmountModifications");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionAmountModifications_AmountModifications",
                table: "TransactionAmountModifications");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionAmountModifications_Transactions",
                table: "TransactionAmountModifications");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionRecurrency_Transaction",
                table: "TransactionRecurrencies");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Category",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionRecurrencies",
                table: "TransactionRecurrencies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionCategories",
                table: "TransactionCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecurrentTransactionLimitations",
                table: "RecurrentTransactionLimitations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecurrentTransactionInstallments",
                table: "RecurrentTransactionInstallments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecurrentTransactionCustomFrequencies",
                table: "RecurrentTransactionCustomFrequencies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AmountModifications",
                table: "AmountModifications");

            migrationBuilder.DropColumn(
                name: "TransactionID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TransactionRecurrencyID",
                table: "TransactionRecurrencies");

            migrationBuilder.DropColumn(
                name: "TransactionCategoryID",
                table: "TransactionCategories");

            migrationBuilder.DropColumn(
                name: "RecurrentTransactionLimitationID",
                table: "RecurrentTransactionLimitations");

            migrationBuilder.DropColumn(
                name: "RecurrentTransactionInstallmentID",
                table: "RecurrentTransactionInstallments");

            migrationBuilder.DropColumn(
                name: "RecurrentTransactionCustomFrequencyID",
                table: "RecurrentTransactionCustomFrequencies");

            migrationBuilder.DropColumn(
                name: "AmountModificationID",
                table: "AmountModifications");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Transactions",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_CategoryID",
                table: "Transactions",
                newName: "IX_Transactions_CategoryId");

            migrationBuilder.RenameColumn(
                name: "AmountModificationID",
                table: "TransactionAmountModifications",
                newName: "AmountModificationId");

            migrationBuilder.RenameColumn(
                name: "TransactionID",
                table: "TransactionAmountModifications",
                newName: "TransactionId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionAmountModifications_AmountModificationID",
                table: "TransactionAmountModifications",
                newName: "IX_TransactionAmountModifications_AmountModificationId");

            migrationBuilder.RenameColumn(
                name: "AmountModificationID",
                table: "RecurrentTransactionSumAmountModifications",
                newName: "AmountModificationId");

            migrationBuilder.RenameColumn(
                name: "RecurrentTransactionLimitationID",
                table: "RecurrentTransactionSumAmountModifications",
                newName: "RecurrentTransactionLimitationId");

            migrationBuilder.RenameIndex(
                name: "IX_RecurrentTransactionSumAmountModifications_AmountModificationID",
                table: "RecurrentTransactionSumAmountModifications",
                newName: "IX_RecurrentTransactionSumAmountModifications_AmountModificationId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Transactions",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 30, 0, 44, 15, 616, DateTimeKind.Local).AddTicks(3493),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2020, 3, 15, 0, 48, 18, 837, DateTimeKind.Local).AddTicks(9483));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Transactions",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TransactionRecurrencies",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TransactionCategories",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "RecurrentTransactionLimitations",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "RecurrentTransactionInstallments",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "RecurrentTransactionCustomFrequencies",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AmountModifications",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionRecurrencies",
                table: "TransactionRecurrencies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionCategories",
                table: "TransactionCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecurrentTransactionLimitations",
                table: "RecurrentTransactionLimitations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecurrentTransactionInstallments",
                table: "RecurrentTransactionInstallments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecurrentTransactionCustomFrequencies",
                table: "RecurrentTransactionCustomFrequencies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AmountModifications",
                table: "AmountModifications",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecurrentTransactionCustomFrequency_TransactionRecurrency",
                table: "RecurrentTransactionCustomFrequencies",
                column: "TransactionRecurrencyId",
                principalTable: "TransactionRecurrencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecurrentTransactionInstallments_TransactionRecurrency",
                table: "RecurrentTransactionInstallments",
                column: "TransactionRecurrencyId",
                principalTable: "TransactionRecurrencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecurrentTransactionLimitation_TransactionRecurrency",
                table: "RecurrentTransactionLimitations",
                column: "TransactionRecurrencyId",
                principalTable: "TransactionRecurrencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecurrentTransactionSumAmountModifications_AmountModifications",
                table: "RecurrentTransactionSumAmountModifications",
                column: "AmountModificationId",
                principalTable: "AmountModifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecurrentTransactionSumAmountModifications_RecurrentTransactionLimitations",
                table: "RecurrentTransactionSumAmountModifications",
                column: "RecurrentTransactionLimitationId",
                principalTable: "RecurrentTransactionLimitations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionAmountModifications_AmountModifications",
                table: "TransactionAmountModifications",
                column: "AmountModificationId",
                principalTable: "AmountModifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionAmountModifications_Transactions",
                table: "TransactionAmountModifications",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionRecurrency_Transaction",
                table: "TransactionRecurrencies",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Category",
                table: "Transactions",
                column: "CategoryId",
                principalTable: "TransactionCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecurrentTransactionCustomFrequency_TransactionRecurrency",
                table: "RecurrentTransactionCustomFrequencies");

            migrationBuilder.DropForeignKey(
                name: "FK_RecurrentTransactionInstallments_TransactionRecurrency",
                table: "RecurrentTransactionInstallments");

            migrationBuilder.DropForeignKey(
                name: "FK_RecurrentTransactionLimitation_TransactionRecurrency",
                table: "RecurrentTransactionLimitations");

            migrationBuilder.DropForeignKey(
                name: "FK_RecurrentTransactionSumAmountModifications_AmountModifications",
                table: "RecurrentTransactionSumAmountModifications");

            migrationBuilder.DropForeignKey(
                name: "FK_RecurrentTransactionSumAmountModifications_RecurrentTransactionLimitations",
                table: "RecurrentTransactionSumAmountModifications");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionAmountModifications_AmountModifications",
                table: "TransactionAmountModifications");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionAmountModifications_Transactions",
                table: "TransactionAmountModifications");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionRecurrency_Transaction",
                table: "TransactionRecurrencies");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Category",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionRecurrencies",
                table: "TransactionRecurrencies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionCategories",
                table: "TransactionCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecurrentTransactionLimitations",
                table: "RecurrentTransactionLimitations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecurrentTransactionInstallments",
                table: "RecurrentTransactionInstallments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecurrentTransactionCustomFrequencies",
                table: "RecurrentTransactionCustomFrequencies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AmountModifications",
                table: "AmountModifications");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TransactionRecurrencies");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TransactionCategories");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RecurrentTransactionLimitations");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RecurrentTransactionInstallments");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RecurrentTransactionCustomFrequencies");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AmountModifications");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Transactions",
                newName: "CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_CategoryId",
                table: "Transactions",
                newName: "IX_Transactions_CategoryID");

            migrationBuilder.RenameColumn(
                name: "AmountModificationId",
                table: "TransactionAmountModifications",
                newName: "AmountModificationID");

            migrationBuilder.RenameColumn(
                name: "TransactionId",
                table: "TransactionAmountModifications",
                newName: "TransactionID");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionAmountModifications_AmountModificationId",
                table: "TransactionAmountModifications",
                newName: "IX_TransactionAmountModifications_AmountModificationID");

            migrationBuilder.RenameColumn(
                name: "AmountModificationId",
                table: "RecurrentTransactionSumAmountModifications",
                newName: "AmountModificationID");

            migrationBuilder.RenameColumn(
                name: "RecurrentTransactionLimitationId",
                table: "RecurrentTransactionSumAmountModifications",
                newName: "RecurrentTransactionLimitationID");

            migrationBuilder.RenameIndex(
                name: "IX_RecurrentTransactionSumAmountModifications_AmountModificationId",
                table: "RecurrentTransactionSumAmountModifications",
                newName: "IX_RecurrentTransactionSumAmountModifications_AmountModificationID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Transactions",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2020, 3, 15, 0, 48, 18, 837, DateTimeKind.Local).AddTicks(9483),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2020, 6, 30, 0, 44, 15, 616, DateTimeKind.Local).AddTicks(3493));

            migrationBuilder.AddColumn<int>(
                name: "TransactionID",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "TransactionRecurrencyID",
                table: "TransactionRecurrencies",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "TransactionCategoryID",
                table: "TransactionCategories",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "RecurrentTransactionLimitationID",
                table: "RecurrentTransactionLimitations",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "RecurrentTransactionInstallmentID",
                table: "RecurrentTransactionInstallments",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "RecurrentTransactionCustomFrequencyID",
                table: "RecurrentTransactionCustomFrequencies",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "AmountModificationID",
                table: "AmountModifications",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "TransactionID")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionRecurrencies",
                table: "TransactionRecurrencies",
                column: "TransactionRecurrencyID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionCategories",
                table: "TransactionCategories",
                column: "TransactionCategoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecurrentTransactionLimitations",
                table: "RecurrentTransactionLimitations",
                column: "RecurrentTransactionLimitationID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecurrentTransactionInstallments",
                table: "RecurrentTransactionInstallments",
                column: "RecurrentTransactionInstallmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecurrentTransactionCustomFrequencies",
                table: "RecurrentTransactionCustomFrequencies",
                column: "RecurrentTransactionCustomFrequencyID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AmountModifications",
                table: "AmountModifications",
                column: "AmountModificationID");

            migrationBuilder.AddForeignKey(
                name: "FK_RecurrentTransactionCustomFrequency_TransactionRecurrency",
                table: "RecurrentTransactionCustomFrequencies",
                column: "TransactionRecurrencyId",
                principalTable: "TransactionRecurrencies",
                principalColumn: "TransactionRecurrencyID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecurrentTransactionInstallments_TransactionRecurrency",
                table: "RecurrentTransactionInstallments",
                column: "TransactionRecurrencyId",
                principalTable: "TransactionRecurrencies",
                principalColumn: "TransactionRecurrencyID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecurrentTransactionLimitation_TransactionRecurrency",
                table: "RecurrentTransactionLimitations",
                column: "TransactionRecurrencyId",
                principalTable: "TransactionRecurrencies",
                principalColumn: "TransactionRecurrencyID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecurrentTransactionSumAmountModifications_AmountModifications",
                table: "RecurrentTransactionSumAmountModifications",
                column: "AmountModificationID",
                principalTable: "AmountModifications",
                principalColumn: "AmountModificationID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecurrentTransactionSumAmountModifications_RecurrentTransactionLimitations",
                table: "RecurrentTransactionSumAmountModifications",
                column: "RecurrentTransactionLimitationID",
                principalTable: "RecurrentTransactionLimitations",
                principalColumn: "RecurrentTransactionLimitationID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionAmountModifications_AmountModifications",
                table: "TransactionAmountModifications",
                column: "AmountModificationID",
                principalTable: "AmountModifications",
                principalColumn: "AmountModificationID",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Category",
                table: "Transactions",
                column: "CategoryID",
                principalTable: "TransactionCategories",
                principalColumn: "TransactionCategoryID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
