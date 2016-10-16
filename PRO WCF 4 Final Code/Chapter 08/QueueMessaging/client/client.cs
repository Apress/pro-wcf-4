using System;
using System.Data;
using System.Messaging;
using System.Configuration;
using System.Web;
using System.Transactions;

namespace QuickReturns
{
    class Client
    {
        static void Main()
        {
            // Create a proxy for the client
            using (TradeServiceClient proxy = new TradeServiceClient())
            {
                //Create a transaction scope.
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    proxy.DoTrade("MSFT", "IBM", 60);
                    Console.WriteLine("Selling 60 stocks of IBM and Buying MSFT ");

                    proxy.DoTrade("ACN","ABN", 100);
                    Console.WriteLine("Selling 60 stocks of ABN and Buying ACN ");

                    // Complete the transaction.
                    scope.Complete();
                }
            }

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
        }
    }
}

