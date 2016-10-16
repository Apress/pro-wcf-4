﻿using System;
using System.Configuration;
using System.Messaging;
using System.ServiceModel;
using System.Transactions;

namespace QuickReturns
{
    // Define a service contract. 
    [ServiceContract]
    public interface ITradeService
    {
        [OperationContract(IsOneWay = true)]
        void DoTrade(string buyStock, string sellStock, int amount);
    }

    // Service class which implements the service contract.
    // Added code to write output to the console window
    public class TradeService : ITradeService
    {
        [OperationBehavior]
        void ITradeService.DoTrade(string buyStock, string sellStock, int amount)
        {
            //Mark the receipt of a transaction
            Console.WriteLine("Recieved Transaction...");
            Console.WriteLine("Received Request to Sell Stock {0} with  the quantity of {1} from And Buy {2}", sellStock.ToString(), amount.ToString(), buyStock.ToString());
            Console.WriteLine();
        }

        // Host the service within this EXE console application.
        public static void Main()
        {
            // Get MSMQ queue name from app settings in configuration
            string queueName = ConfigurationManager.AppSettings["queueName"];

            // Create the transacted MSMQ queue if necessary.
            if (!MessageQueue.Exists(queueName))
                MessageQueue.Create(queueName, true);

            // Get the base address that is used to listen for WS-MetaDataExchange requests
            // This is useful to generate a proxy for the client
            string baseAddress = ConfigurationManager.AppSettings["baseAddress"];

            // Create a ServiceHost for the TradeService type.
            using (ServiceHost serviceHost = new ServiceHost(typeof(TradeService), new Uri(baseAddress)))
            {
                serviceHost.Open();

                Console.WriteLine("The Trade Service is online.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                // Close the ServiceHostBase to shutdown the service.
                serviceHost.Close();
            }
        }
    }
}
