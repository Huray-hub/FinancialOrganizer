using Domain.Entities.Transaction;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Domain
{
    public class AppUser: IdentityUser
    {
        public AppUser()
        {
            Transactions = new HashSet<Transaction>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}
