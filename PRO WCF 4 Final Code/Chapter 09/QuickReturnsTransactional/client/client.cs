using System;
using System.ServiceModel;
using System.Transactions;

namespace QuickReturns
{
    //The service contract is defined in generatedClient.cs, generated from the service by the svcutil tool.

    //Client implementation code.
    class Client
    {
        static void Main()
        {
            // Create a client using either wsat or oletx endpoint configurations
            TradeServiceClient client = new TradeServiceClient("WSAtomicTransaction_endpoint");
            // TradeServiceClient client = new TradeServiceClient("OleTransactions_endpoint");

            // Start a transaction scope
            using (TransactionScope tx =
                        new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                Console.WriteLine("Starting transaction");

                // Call the Add service operation
                //  - generatedClient will flow the required active transaction
                int qty;
                int price;
                int result;
                

                // Call the CalculateTradeValue service operation
                // - generatedClient will not flow the active transaction
                qty = 100;
                price = 15;
                result = client.CalculateTradeValue(qty, price);
                Console.WriteLine("  Sold ACN Qantity {0}, For$ {1} With a Total Value of ${2}", qty, price, result);

                                // Complete the transaction scope
                Console.WriteLine("  Completing transaction");
                tx.Complete();
            }

            Console.WriteLine("Transaction committed");

            // Closing the client gracefully closes the connection and cleans up resources
            client.Close();

            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
        }
    }
}