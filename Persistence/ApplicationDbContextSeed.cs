using Domain;
using Domain.Entities.Transaction;
using Domain.Enumerations;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
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

            if (!context.TransactionCategories.Any())
            {
                var categories = new List<TransactionCategory>
                {
                    new TransactionCategory
                    {
                        Name = "Goverment Taxes"
                    },
                    new TransactionCategory
                    {
                        Name = "Entertainment"
                    },
                    new TransactionCategory
                    {
                        Name = "Residence"
                    },
                    new TransactionCategory
                    {
                        Name = "Health"
                    },
                    new TransactionCategory
                    {
                        Name = "Income"
                    }
                };
                await context.TransactionCategories.AddRangeAsync(categories);
            }

            if (!context.AmountModificationCategories.Any())
            {
                var amountModificationCategories = new List<AmountModificationCategory>
                {
                    new AmountModificationCategory
                    {                        
                        Title = "VAT 24/100"
                    },
                    new AmountModificationCategory
                    {                       
                        Title = "Dicount 200"
                    },
                    new AmountModificationCategory
                    {                      
                        Title = "AmountModCategory 3"
                    }
                };
                await context.AmountModificationCategories.AddRangeAsync(amountModificationCategories);

                var amountModifications = new List<AmountModification>
                {
                    new AmountModification
                    {
                        Amount = 24,
                        AmountType = 0,
                        AmountCalculationType = 1,
                        AmountModificationCategoryId = 1
                    },
                    new AmountModification
                    {
                        Amount = 200,
                        AmountType = 1,
                        AmountCalculationType = 0,
                        AmountModificationCategoryId = 2
                    },
                    new AmountModification
                    {
                        Amount = 100,
                        AmountType = 0,
                        AmountCalculationType = 0,
                        AmountModificationCategoryId = 3
                    }
                };
                await context.AmountModifications.AddRangeAsync(amountModifications);
            }

            if (!context.Transactions.Any())
            {
                var transactions = new List<Transaction>
                {
                    new Transaction
                    {
                        Title = "Enfia oikopedou",
                        Type = (int)TransactionType.Expense,
                        Currency = (int)Currency.Euro,
                        IsRecurrent = true,
                        UserId = "a",
                        CategoryId = 1,
                        TransactionAmount = new TransactionAmount
                        {
                            Amount = 20.52M,
                            TriggerDate = DateTime.Now.AddDays(27),
                            TransactionRecurrency = new TransactionRecurrency
                            {
                                HasLimitations = true,
                                FrequencyType = (int)TransactionFrequencyType.Monthly,
                                RecurrentTransactionLimitation = new RecurrentTransactionLimitation
                                {
                                    RecurrencyNumber = 120,
                                    EndDate = DateTime.Now.AddYears(10),
                                    SumAmount = 307.82M
                                }
                            }
                        }
                    },
                    new Transaction
                    {
                        Title = "Gym fee",
                        Type = (int)TransactionType.Expense,
                        Currency = (int)Currency.Euro,
                        IsRecurrent = true,
                        UserId = "a",
                        CategoryId = 4,
                        TransactionAmount = new TransactionAmount
                        {
                            Amount = 50,
                            MaxAmount = 70,
                            TriggerDate = DateTime.Now.AddDays(7),
                            TransactionRecurrency = new TransactionRecurrency
                            {
                                HasLimitations = false,
                                FrequencyType = (int)TransactionFrequencyType.Monthly
                            }
                        }
                    },
                    new Transaction
                    {
                        Title = "Salary",
                        Type = (int)TransactionType.Revenue,
                        Currency = (int)Currency.Euro,
                        IsRecurrent = true,
                        UserId = "a",
                        CategoryId = 5,
                        TransactionAmount = new TransactionAmount
                        {
                            Amount = 750,
                            TriggerDate = DateTime.Now.AddDays(26),
                            TransactionRecurrency = new TransactionRecurrency
                            {
                                HasLimitations = false,
                                FrequencyType = (int)TransactionFrequencyType.Monthly
                            }
                        }
                    },
                    new Transaction
                    {
                        Title = "Dentist",
                        Type = (int)TransactionType.Expense,
                        Currency = (int)Currency.Euro,
                        IsRecurrent = true,
                        UserId = "a",
                        CategoryId = 4,
                        TransactionAmount = new TransactionAmount
                        {
                            Amount = 50,
                            TriggerDate = DateTime.Now.AddMonths(2),
                            TransactionRecurrency = new TransactionRecurrency
                            {
                                HasLimitations = false,
                                FrequencyType = (int)TransactionFrequencyType.Custom,
                                RecurrentTransactionCustomFrequency = new RecurrentTransactionCustomFrequency
                                {
                                    TimeUnit = (int)TimeUnits.Months,
                                    TimeUnitQuantity = 6
                                }
                            }
                        }
                    },
                    new Transaction
                    {
                        Title = "Coffee",
                        Type = (int)TransactionType.Expense,
                        Currency = (int)Currency.Euro,
                        IsRecurrent = true,
                        UserId = "a",
                        CategoryId = 2,
                        TransactionAmount = new TransactionAmount
                        {
                            Amount = 1.80M,
                            MaxAmount = 4.80M,
                            TriggerDate = DateTime.Now,
                            TransactionRecurrency = new TransactionRecurrency
                            {
                                HasLimitations = false,
                                FrequencyType = (int)TransactionFrequencyType.Daily
                            }
                        }
                    },
                    new Transaction
                    {
                        Title = "New Shoes",
                        Type = (int)TransactionType.Expense,
                        Currency = (int)Currency.Euro,
                        IsRecurrent = true,
                        UserId = "a",
                        CategoryId = 2,
                        TransactionAmount = new TransactionAmount
                        {
                            Amount = 15,
                            TriggerDate = DateTime.Now,
                            TransactionRecurrency = new TransactionRecurrency
                            {
                                HasLimitations = true,
                                FrequencyType = (int)TransactionFrequencyType.Monthly,
                                RecurrentTransactionLimitation = new RecurrentTransactionLimitation
                                {
                                    SumAmount = 90,
                                    RecurrencyNumber = 6,
                                    EndDate = DateTime.Now.AddMonths(6)
                                }
                            }
                        }
                    }
                };
                await context.Transactions.AddRangeAsync(transactions);
            }

            await context.SaveChangesAsync();
        }
    }
}

