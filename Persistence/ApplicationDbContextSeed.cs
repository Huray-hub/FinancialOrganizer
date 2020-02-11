using Domain;
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
        public static async Task SeedAsync(ApplicationDbContext context,UserManager<AppUser> userManager)
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
                        Id = Guid.Parse("4ff354d8-0e02-4eea-85ca-9b318c33b097"),
                        Name = "Goverment Taxes"
                    },
                    new TransactionCategory
                    {
                        Id = Guid.Parse("9873f048-f8d7-4f39-a89c-386e64eeb488"),
                        Name = "Personal Fees"
                    },
                    new TransactionCategory
                    {
                        Id = Guid.Parse("1db0f93c-069c-4021-805c-2943d7203d9c"),
                        Name = "Other Category Example"
                    }
                };
                await context.TransactionCategories.AddRangeAsync(categories);

                var amountModificationCategories = new List<AmountModificationCategory>
                {
                    new AmountModificationCategory
                    {
                        Id = Guid.Parse("05a2863e-9b29-4a33-ac4d-044145b81a9f"),
                        Title = "VAT"
                    },
                    new AmountModificationCategory
                    {
                        Id = Guid.Parse("4625c9b8-6b16-44e9-8f8e-d1031637af99"),
                        Title = "AmountModCategory 2"
                    },
                    new AmountModificationCategory
                    {
                        Id = Guid.Parse("d941f609-d4e0-4459-9617-fea666329805"),
                        Title = "AmountModCategory 3"
                    }
                };
                await context.AmountModificationCategories.AddRangeAsync(amountModificationCategories);

                var amountModifications = new List<AmountModification>
                {
                    new AmountModification
                    {
                        Id = Guid.Parse("f40a4b44-616e-41e0-a8ff-12d0f72ec852"),
                        Amount = 160,
                        AmountModificationCategoryId = Guid.Parse("")
                    }
                }
                await context.AmountModifications.AddRangeAsync(amountModifications);
            }
        }
    }
}
