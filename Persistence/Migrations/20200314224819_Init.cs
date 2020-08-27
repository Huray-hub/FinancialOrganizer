using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Persistence.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AmountModifications",
                columns: table => new
                {
                    AmountModificationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    AmountType = table.Column<int>(name: "Amount Type", nullable: false),
                    AmountCalculationType = table.Column<int>(name: "Amount Calculation Type", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmountModifications", x => x.AmountModificationID);
                });

            migrationBuilder.CreateTable(
                name: "TransactionCategories",
                columns: table => new
                {
                    TransactionCategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionCategories", x => x.TransactionCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2020, 3, 15, 0, 48, 18, 837, DateTimeKind.Local).AddTicks(9483)),
                    LastModifiedByUserId = table.Column<string>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Currency = table.Column<int>(nullable: false),
                    TransactionAmountId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    MaxAmount = table.Column<decimal>(name: "Max Amount", type: "money", nullable: true),
                    TriggerDate = table.Column<DateTime>(name: "Trigger Date", type: "smalldatetime", nullable: false),
                    IsRecurrent = table.Column<bool>(nullable: false, defaultValue: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionID)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Transactions_Category",
                        column: x => x.CategoryID,
                        principalTable: "TransactionCategories",
                        principalColumn: "TransactionCategoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransactionAmountModifications",
                columns: table => new
                {
                    TransactionID = table.Column<int>(nullable: false),
                    AmountModificationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionAmountModifications", x => new { x.TransactionID, x.AmountModificationID });
                    table.ForeignKey(
                        name: "FK_TransactionAmountModifications_AmountModifications",
                        column: x => x.AmountModificationID,
                        principalTable: "AmountModifications",
                        principalColumn: "AmountModificationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionAmountModifications_Transactions",
                        column: x => x.TransactionID,
                        principalTable: "Transactions",
                        principalColumn: "TransactionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionRecurrencies",
                columns: table => new
                {
                    TransactionRecurrencyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HasLimitations = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    FrequencyType = table.Column<int>(name: "Frequency Type", nullable: false),
                    TransactionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionRecurrencies", x => x.TransactionRecurrencyID);
                    table.ForeignKey(
                        name: "FK_TransactionRecurrency_Transaction",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "TransactionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecurrentTransactionCustomFrequencies",
                columns: table => new
                {
                    RecurrentTransactionCustomFrequencyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeUnit = table.Column<int>(name: "Time Unit", nullable: false),
                    TimeUnitQuantity = table.Column<int>(name: "Time Unit Quantity", nullable: false),
                    TransactionRecurrencyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecurrentTransactionCustomFrequencies", x => x.RecurrentTransactionCustomFrequencyID);
                    table.ForeignKey(
                        name: "FK_RecurrentTransactionCustomFrequency_TransactionRecurrency",
                        column: x => x.TransactionRecurrencyId,
                        principalTable: "TransactionRecurrencies",
                        principalColumn: "TransactionRecurrencyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecurrentTransactionInstallments",
                columns: table => new
                {
                    RecurrentTransactionInstallmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentInstallment = table.Column<int>(name: "Current Installment", nullable: false),
                    InstallmentTriggerDate = table.Column<DateTime>(name: "Installment Trigger Date", type: "smalldatetime", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "RecurrentTransactionLimitations",
                columns: table => new
                {
                    RecurrentTransactionLimitationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SumInstallments = table.Column<int>(name: "Sum Installments", nullable: false),
                    EndDate = table.Column<DateTime>(name: "End Date", type: "smalldatetime", nullable: false),
                    SumAmount = table.Column<decimal>(name: "Sum Amount", nullable: false),
                    MaxSumAmount = table.Column<decimal>(name: "Max Sum Amount", nullable: true),
                    TransactionRecurrencyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecurrentTransactionLimitations", x => x.RecurrentTransactionLimitationID);
                    table.ForeignKey(
                        name: "FK_RecurrentTransactionLimitation_TransactionRecurrency",
                        column: x => x.TransactionRecurrencyId,
                        principalTable: "TransactionRecurrencies",
                        principalColumn: "TransactionRecurrencyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecurrentTransactionSumAmountModifications",
                columns: table => new
                {
                    RecurrentTransactionLimitationID = table.Column<int>(nullable: false),
                    AmountModificationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecurrentTransactionSumAmountModifications", x => new { x.RecurrentTransactionLimitationID, x.AmountModificationID });
                    table.ForeignKey(
                        name: "FK_RecurrentTransactionSumAmountModifications_AmountModifications",
                        column: x => x.AmountModificationID,
                        principalTable: "AmountModifications",
                        principalColumn: "AmountModificationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecurrentTransactionSumAmountModifications_RecurrentTransactionLimitations",
                        column: x => x.RecurrentTransactionLimitationID,
                        principalTable: "RecurrentTransactionLimitations",
                        principalColumn: "RecurrentTransactionLimitationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecurrentTransactionCustomFrequencies_TransactionRecurrencyId",
                table: "RecurrentTransactionCustomFrequencies",
                column: "TransactionRecurrencyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecurrentTransactionInstallments_TransactionRecurrencyId",
                table: "RecurrentTransactionInstallments",
                column: "TransactionRecurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_RecurrentTransactionLimitations_TransactionRecurrencyId",
                table: "RecurrentTransactionLimitations",
                column: "TransactionRecurrencyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecurrentTransactionSumAmountModifications_AmountModificationID",
                table: "RecurrentTransactionSumAmountModifications",
                column: "AmountModificationID");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionAmountModifications_AmountModificationID",
                table: "TransactionAmountModifications",
                column: "AmountModificationID");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionRecurrencies_TransactionId",
                table: "TransactionRecurrencies",
                column: "TransactionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CategoryID",
                table: "Transactions",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecurrentTransactionCustomFrequencies");

            migrationBuilder.DropTable(
                name: "RecurrentTransactionInstallments");

            migrationBuilder.DropTable(
                name: "RecurrentTransactionSumAmountModifications");

            migrationBuilder.DropTable(
                name: "TransactionAmountModifications");

            migrationBuilder.DropTable(
                name: "RecurrentTransactionLimitations");

            migrationBuilder.DropTable(
                name: "AmountModifications");

            migrationBuilder.DropTable(
                name: "TransactionRecurrencies");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "TransactionCategories");
        }
    }
}
