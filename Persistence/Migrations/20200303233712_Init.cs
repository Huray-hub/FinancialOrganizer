using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AmountModificationCategories",
                columns: table => new
                {
                    AmountModificationCategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmountModificationCategories", x => x.AmountModificationCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: false),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(name: "First Name", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(name: "Last Name", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(name: "Date Of Birth", type: "Date", nullable: false),
                    Country = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
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
                name: "AmountModifications",
                columns: table => new
                {
                    AmountModificationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    AmountType = table.Column<int>(name: "Amount Type", nullable: false),
                    AmountCalculationType = table.Column<int>(name: "Amount Calculation Type", nullable: false, defaultValue: 0),
                    AmountModificationCategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmountModifications", x => x.AmountModificationID);
                    table.ForeignKey(
                        name: "FK_AmountModifications_AmountModificationCategory",
                        column: x => x.AmountModificationCategoryID,
                        principalTable: "AmountModificationCategories",
                        principalColumn: "AmountModificationCategoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Currency = table.Column<int>(nullable: false),
                    IsRecurrent = table.Column<bool>(nullable: false, defaultValue: false),
                    UserID = table.Column<string>(nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Transactions_User",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionAmounts",
                columns: table => new
                {
                    TransactionAmountID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    MaxAmount = table.Column<decimal>(name: "Max Amount", type: "money", nullable: true),
                    TriggerDate = table.Column<DateTime>(name: "Trigger Date", type: "smalldatetime", nullable: false),
                    TransactionId = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "TransactionAmountModifications",
                columns: table => new
                {
                    TransactionAmountID = table.Column<int>(nullable: false),
                    AmountModificationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionAmountModifications", x => new { x.TransactionAmountID, x.AmountModificationID });
                    table.ForeignKey(
                        name: "FK_TransactionAmountModifications_AmountModifications",
                        column: x => x.AmountModificationID,
                        principalTable: "AmountModifications",
                        principalColumn: "AmountModificationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionAmountModifications_TransactionAmounts",
                        column: x => x.TransactionAmountID,
                        principalTable: "TransactionAmounts",
                        principalColumn: "TransactionAmountID",
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
                    TransactionAmountId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionRecurrencies", x => x.TransactionRecurrencyID);
                    table.ForeignKey(
                        name: "FK_TransactionRecurrency_TransactionAmount",
                        column: x => x.TransactionAmountId,
                        principalTable: "TransactionAmounts",
                        principalColumn: "TransactionAmountID",
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
                name: "RecurrentTransactionInfo",
                columns: table => new
                {
                    RecurrentTransactionInfoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentTransaction = table.Column<int>(nullable: false),
                    CurrentTriggerDate = table.Column<DateTime>(nullable: false),
                    TransactionRecurrencyId = table.Column<int>(nullable: false)
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
                name: "RecurrentTransactionLimitations",
                columns: table => new
                {
                    RecurrentTransactionLimitationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecurrencyNumber = table.Column<int>(name: "Recurrency Number", nullable: false),
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
                name: "IX_AmountModifications_AmountModificationCategoryID",
                table: "AmountModifications",
                column: "AmountModificationCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RecurrentTransactionCustomFrequencies_TransactionRecurrencyId",
                table: "RecurrentTransactionCustomFrequencies",
                column: "TransactionRecurrencyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecurrentTransactionInfo_TransactionRecurrencyId",
                table: "RecurrentTransactionInfo",
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
                name: "IX_TransactionAmounts_TransactionId",
                table: "TransactionAmounts",
                column: "TransactionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionRecurrencies_TransactionAmountId",
                table: "TransactionRecurrencies",
                column: "TransactionAmountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CategoryID",
                table: "Transactions",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserID",
                table: "Transactions",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "RecurrentTransactionCustomFrequencies");

            migrationBuilder.DropTable(
                name: "RecurrentTransactionInfo");

            migrationBuilder.DropTable(
                name: "RecurrentTransactionSumAmountModifications");

            migrationBuilder.DropTable(
                name: "TransactionAmountModifications");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "RecurrentTransactionLimitations");

            migrationBuilder.DropTable(
                name: "AmountModifications");

            migrationBuilder.DropTable(
                name: "TransactionRecurrencies");

            migrationBuilder.DropTable(
                name: "AmountModificationCategories");

            migrationBuilder.DropTable(
                name: "TransactionAmounts");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "TransactionCategories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
