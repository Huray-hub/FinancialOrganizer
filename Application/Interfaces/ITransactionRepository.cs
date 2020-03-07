using Domain.Entities.Transaction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface ITransactionRepository
    {
        ICollection<Transaction> GetAllTransactions();
        ICollection<Transaction> GetTransactionsPerUser(string userId);
        ICollection<Transaction> GetTransactionById(int id);

        ICollection<Transaction> GetExpensesByUser(string userId);

        ICollection<Transaction> GetTransactionsPerDateRange(string userId, DateTime startDate, DateTime? endDate);



        //Get Expenses
        //Get Revenues
        //Get Transactions per Month
        //Get Expenses per Month, per Date Range
        //Get Revenues per Month, per Date Range
        //Get Recurrent Transactions
    }
}
