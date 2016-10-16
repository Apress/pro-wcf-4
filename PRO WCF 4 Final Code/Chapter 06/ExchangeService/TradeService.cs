using System;
using System.ServiceModel;

namespace ExchangeService
{
    [ServiceContract(
        Namespace = "http://PracticalWcf/Exchange/TradeService",
        Name = "TradeService")
    ]
    public interface ITradeService
    {
        [OperationContract]
        double TradeSecurity(string ticker, int quantity);
    }
    public class TradeService : ITradeService, ITradeMonitor
    {
        const double IBM_Price = 80.50D;
        const double MSFT_Price = 30.25D;

        public double TradeSecurity(string ticker, int quantity)
        {
            if (quantity < 1)
                throw new ArgumentException(
                    "Invalid quantity", "quantity");
            switch (ticker.ToLower())
            {
                case "ibm":
                    return quantity * IBM_Price;
                case "msft":
                    return quantity * MSFT_Price;
                default:
                    throw new ArgumentException(
                        "Don't know - only MSFT & IBM", "ticker");
            }
        }
        public string StartMonitoring(string ticker)
        {
            lock (this)
            {
                // Start the monitoring process here. I.e. - You can configure
                // This function to start a manual log file or
                // or send information to the event log. For this example we are
                // returning a string to indicate that the monitoring has commenced. 
                return "Monitoring has started for " + ticker;
            }
        }
        public string StopMonitoring(string ticker)
        {
            lock (this)
            {
                // End the monitoring process here. 
                return "Monitoring has finished for " + ticker;
            }
        }
    }
}