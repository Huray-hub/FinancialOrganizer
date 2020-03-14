using Domain;
using Domain.Entities.Transaction;
using Domain.Enumerations;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence
{
    public class FinancialOrganizerDbContextSeed
    {
        public static async Task SeedAsync(FinancialOrganizerDbContext context)
        {
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
                        Name = "Salary"
                    }
                };
                await context.TransactionCategories.AddRangeAsync(categories);
            }

            if (!context.AmountModifications.Any())
            {
                var amountModifications = new List<AmountModification>
                {
                    new AmountModification
                    {
                        Title = "VAT",
                        Amount = 24,
                        AmountType = 0,
                        AmountCalculationType = 1
                    },
                    new AmountModification
                    {
                        Title = "Ekptwsi",
                        Amount = 200,
                        AmountType = 1,
                        AmountCalculationType = 0,
                    },
                    new AmountModification
                    {
                        Title = "Flat epivarinsi posou",
                        Amount = 100,
                        AmountType = 0,
                        AmountCalculationType = 0
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
                        CreatedByUserId = "a",
                        CreatedAt = DateTime.Now,
                        CategoryId = 1,
                        Amount = 20.52M,
                        TriggerDate = DateTime.Now.AddDays(27),
                        TransactionRecurrency = new TransactionRecurrency
                        {
                            HasLimitations = true,
                            FrequencyType = (int)TransactionFrequencyType.Monthly,
                            RecurrentTransactionLimitation = new RecurrentTransactionLimitation
                            {
                                SumInstallments = 120,
                                EndDate = DateTime.Now.AddYears(10),
                                SumAmount = 307.82M
                            }
                        },


                    },
                    new Transaction
                    {
                        Title = "Gym fee",
                        Type = (int)TransactionType.Expense,
                        Currency = (int)Currency.Euro,
                        IsRecurrent = true,
                        CreatedByUserId = "a",
                        CreatedAt = DateTime.Now,
                        CategoryId = 4,
                        Amount = 50,
                        MaxAmount = 70,
                        TriggerDate = DateTime.Now.AddDays(7),
                        TransactionRecurrency = new TransactionRecurrency
                        {
                            HasLimitations = false,
                            FrequencyType = (int)TransactionFrequencyType.Monthly
                        }

                    },
                    new Transaction
                    {
                        Title = "Salary",
                        Type = (int)TransactionType.Revenue,
                        Currency = (int)Currency.Euro,
                        IsRecurrent = true,
                        CreatedByUserId = "a",
                        CreatedAt = DateTime.Now,
                        CategoryId = 5,
                        Amount = 750,
                        TriggerDate = DateTime.Now.AddDays(26),
                        TransactionRecurrency = new TransactionRecurrency
                        {
                            HasLimitations = false,
                            FrequencyType = (int)TransactionFrequencyType.Monthly
                        }
                    },
                    new Transaction
                    {
                        Title = "Dentist",
                        Type = (int)TransactionType.Expense,
                        Currency = (int)Currency.Euro,
                        IsRecurrent = true,
                        CreatedByUserId = "a",
                        CreatedAt = DateTime.Now,
                        CategoryId = 4,
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
                    },
                    new Transaction
                    {
                        Title = "Coffee",
                        Type = (int)TransactionType.Expense,
                        Currency = (int)Currency.Euro,
                        IsRecurrent = true,
                        CreatedByUserId = "a",
                        CreatedAt = DateTime.Now,
                        CategoryId = 2,
                        Amount = 1.80M,
                        MaxAmount = 4.80M,
                        TriggerDate = DateTime.Now,
                        TransactionRecurrency = new TransactionRecurrency
                        {
                            HasLimitations = false,
                            FrequencyType = (int)TransactionFrequencyType.Daily
                        }
                    },
                    new Transaction
                    {
                        Title = "New Shoes",
                        Type = (int)TransactionType.Expense,
                        Currency = (int)Currency.Euro,
                        IsRecurrent = true,
                        CreatedByUserId = "a",
                        CreatedAt = DateTime.Now,
                        CategoryId = 2,
                        Amount = 15,
                        TriggerDate = DateTime.Now,
                        TransactionRecurrency = new TransactionRecurrency
                        {
                            HasLimitations = true,
                            FrequencyType = (int)TransactionFrequencyType.Monthly,
                            RecurrentTransactionLimitation = new RecurrentTransactionLimitation
                            {
                                SumAmount = 90,
                                SumInstallments = 6,
                                EndDate = DateTime.Now.AddMonths(6)
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

