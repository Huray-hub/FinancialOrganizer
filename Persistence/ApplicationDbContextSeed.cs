using Domain;
using Domain.Enumerations;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        Id = "a",
                        UserName = "Panos",
                        Email = "panos@gmail.com",
                        FirstName = "Panos",
                        LastName = "Morepanos",
                        DateOfBirth = new DateTime(1996,09,12),
                        Country = "Greece",
                    },
                    new AppUser
                    {
                        Id = "b",
                        UserName = "Helen",
                        Email = "helen@gmail.com",
                        FirstName = "Helen",
                        LastName = "Morehelen",
                        DateOfBirth = new DateTime(1994,04,2),
                        Country = "Greece"
                    },
                    new AppUser
                    {
                        Id = "c",
                        UserName = "Michael",
                        Email = "michael@gmail.com",
                        FirstName = "Michael",
                        LastName = "MoreMichael",
                        DateOfBirth = new DateTime(1998, 01, 12),
                        Country = "Greece"
                    },
                    new AppUser
                    {
                        Id="d",
                        UserName = "Antonia",
                        Email = "antonia@gmail.com",
                        FirstName = "Antonia",
                        LastName = "MoreAntonia",
                        DateOfBirth = new DateTime(1996,10,21),
                        Country = "Greece"
                    }

                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Ab123456!");
                }
            }

            if (!context.Transactions.Any())
            {
                var categories = new List<TransactionCategory>
                {
                    new TransactionCategory
                    {
                        TransactionCategoryId = Guid.Parse("4ff354d8-0e02-4eea-85ca-9b318c33b097"),
                        Name = "Goverment Taxes"
                    },
                    new TransactionCategory
                    {
                        TransactionCategoryId = Guid.Parse("9873f048-f8d7-4f39-a89c-386e64eeb488"),
                        Name = "Personal Fees"
                    },
                    new TransactionCategory
                    {
                        TransactionCategoryId = Guid.Parse("1db0f93c-069c-4021-805c-2943d7203d9c"),
                        Name = "Other Category Example"
                    }
                };
                await context.TransactionCategories.AddRangeAsync(categories);

                var amountModificationCategories = new List<AmountModificationCategory>
                {
                    new AmountModificationCategory
                    {
                        AmountModificationCategoryId = Guid.Parse("05a2863e-9b29-4a33-ac4d-044145b81a9f"),
                        Title = "VAT"
                    },
                    new AmountModificationCategory
                    {
                        AmountModificationCategoryId = Guid.Parse("4625c9b8-6b16-44e9-8f8e-d1031637af99"),
                        Title = "AmountModCategory 2"
                    },
                    new AmountModificationCategory
                    {
                        AmountModificationCategoryId = Guid.Parse("d941f609-d4e0-4459-9617-fea666329805"),
                        Title = "AmountModCategory 3"
                    }
                };
                await context.AmountModificationCategories.AddRangeAsync(amountModificationCategories);

                var amountModifications = new List<AmountModification>
                {
                    new AmountModification
                    {
                        AmountModificationId = Guid.Parse("f40a4b44-616e-41e0-a8ff-12d0f72ec852"),
                        Amount = 24,
                        AmountType = 0,
                        AmountCalculationType = 1,
                        AmountModificationCategoryId = Guid.Parse("05a2863e-9b29-4a33-ac4d-044145b81a9f")
                    },
                    new AmountModification
                    {
                        AmountModificationId = Guid.Parse("a0511848-c9fc-424a-97ac-06c98181e2d3"),
                        Amount = 200,
                        AmountType = 1,
                        AmountCalculationType = 0,
                        AmountModificationCategoryId = Guid.Parse("4625c9b8-6b16-44e9-8f8e-d1031637af99")
                    },
                    new AmountModification
                    {
                        AmountModificationId = Guid.Parse("7728bef7-fd33-4a23-bdad-308ba00d8f6a"),
                        Amount = 100,
                        AmountType = 0,
                        AmountCalculationType = 0,
                        AmountModificationCategoryId = Guid.Parse("4625c9b8-6b16-44e9-8f8e-d1031637af99")
                    }
                };
                await context.AmountModifications.AddRangeAsync(amountModifications);

                var transactions = new List<Transaction>
                {
                    new Transaction
                    {
                        TransactionId = Guid.Parse("52a42c49-63a1-445a-98df-6ca1898faf74"),
                        Title = "Enfia oikopedou",
                        Type = (int)TransactionType.Expense,
                        Currency = (int)Currency.Euro,
                        ExactAmount = 20.18M,
                        FrequencyRangeStart = new DateTime(2020,09,02),
                        FrequencyRangeEnd = new DateTime(2020,09,02),
                        UserId = "a",
                        CategoryId = Guid.Parse("4ff354d8-0e02-4eea-85ca-9b318c33b097"),
                    },
                    new Transaction
                    {
                        TransactionId = Guid.Parse("24b6c42e-3622-4555-a993-452b3e5e7512"),
                        Title = "Gym fee",
                        Type = (int)TransactionType.Expense,
                        Currency = (int)Currency.Euro,
                        ExactAmount = 50,
                        FrequencyRangeStart = new DateTime(2020,10,12),
                        FrequencyRangeEnd = new DateTime(2020,11,2),
                        UserId = "a",
                        CategoryId = Guid.Parse("9873f048-f8d7-4f39-a89c-386e64eeb488")
                    },
                    new Transaction
                    {
                        TransactionId = Guid.Parse("8cbd28d4-b27e-44cf-926d-cb7161bee01a"),
                        Title = "Salary",
                        Type = (int)TransactionType.Revenue,
                        Currency = (int)Currency.Euro,
                        ExactAmount = 750,
                        FrequencyRangeStart = new DateTime(2020,10,15),
                        FrequencyRangeEnd = new DateTime(2020,10,20),
                        UserId = "a",
                        CategoryId = Guid.Parse("1db0f93c-069c-4021-805c-2943d7203d9c")
                    }
                };
                await context.Transactions.AddRangeAsync(transactions);

                var transactionAmountModifications = new List<TransactionAmountModification>
                {
                    new TransactionAmountModification
                    {
                        TransactionId = Guid.Parse("24b6c42e-3622-4555-a993-452b3e5e7512"),
                        AmountModificationId = Guid.Parse("f40a4b44-616e-41e0-a8ff-12d0f72ec852")
                    },
                    new TransactionAmountModification
                    {
                        TransactionId = Guid.Parse("8cbd28d4-b27e-44cf-926d-cb7161bee01a"),
                        AmountModificationId = Guid.Parse("7728bef7-fd33-4a23-bdad-308ba00d8f6a")
                    }
                };
                await context.TransactionAmountModifications.AddRangeAsync(transactionAmountModifications);

                await context.SaveChangesAsync();
            }
        }
    }
}
