using System;
using System.Transactions;

namespace QuickReturns
{
    class Client
    {
        public static void Main()
        {
            // Create a proxy for the client
            using (TradeServiceClient proxy = new TradeServiceClient())
            {
                //Create a transaction scope. This is the only line of code required to enable transactions in WCF using MSMQ
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    proxy.DoTrade("MSFT", "IBM", 60);
                    Console.WriteLine("Begining Transaction ....");
                    Console.WriteLine("Selling 1000 stocks of ACN and Buying IBM ");
                    Console.WriteLine("");
                    //Mark the begining of the second transaction..

                    proxy.DoTrade("ACN", "ABN", 100);
                    Console.WriteLine("Selling 100 stocks of ABN and Buying ACN ");
                    Console.WriteLine("Ending Transaction ....");

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

