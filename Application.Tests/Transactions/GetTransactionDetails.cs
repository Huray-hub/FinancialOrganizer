using Application.Transactions.Queries;
using Application.Transactions.Queries.GetTransactionsList;
using NUnit.Framework;
using System;

namespace Application.Tests.Transactions
{
    [TestFixture]
    public class GetTransactionDetails
    {
       

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var Id1 = 0;
           
            var Id2 = -1;

            var transaction1 = new TransactionDetailsQuery() 
            { 
                Id = Id1, 
                IncludeNavigationProperties = false
            };

            var transaction2 = new TransactionDetailsQuery()
            {
                Id = Id2,
                IncludeNavigationProperties = false
            };
        }



        [Test]
        [TestCase()]
        public void ThrowNullException()
        {
            //Arange


            //Act

            //Assert
            //Assert.That(() => new TransactionsDetailsQuery(), Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}
