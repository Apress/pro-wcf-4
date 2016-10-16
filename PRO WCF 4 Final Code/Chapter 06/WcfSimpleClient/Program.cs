using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel.Channels;

namespace ExchangeService
{
    class Program
    {
        static void Main(string[] args)
        {
            ITradeService proxy = new System.ServiceModel.ChannelFactory<ITradeService>("TradeServiceConfiguration").CreateChannel();
            ITradeMonitor monitor = new System.ServiceModel.ChannelFactory<ITradeMonitor>("TradeMonitorConfiguration").CreateChannel();
            Console.WriteLine("\nTrade IBM");
            Console.WriteLine(monitor.StartMonitoring("IBM"));
            double result = proxy.TradeSecurity("IBM", 1000);
            Console.WriteLine("Cost was " + result);
            Console.WriteLine(monitor.StopMonitoring("IBM"));
            Console.WriteLine("\nTrade MSFT");
            result = proxy.TradeSecurity("MSFT", 2000);
            Console.WriteLine("Cost was " + result);
            try
            {
                Console.WriteLine("\nTrade ATT");
                result = proxy.TradeSecurity("T", 3000);
                Console.WriteLine("Cost was " + result);
            }
            catch (Exception ex)
            {
                Console.Write("Exception was: " + ex.Message);
            }

            Console.WriteLine("\n\nPress <enter> to exit...");
            Console.ReadLine();
        }
    }
}
