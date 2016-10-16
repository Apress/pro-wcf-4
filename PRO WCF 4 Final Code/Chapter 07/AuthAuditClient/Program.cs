using System;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.Threading;

namespace ExchangeService
{
    class Program
    {
        static void Main( string[] args )
        {
            EndpointAddress address =
               new EndpointAddress("http://localhost:8001/TradeService");
            WSHttpBinding binding = new WSHttpBinding();
            System.ServiceModel.ChannelFactory<ITradeService> cf =
                new ChannelFactory<ITradeService>(binding, address);
            ITradeService proxy = cf.CreateChannel();

            Console.WriteLine("\nTrade IBM");
            try
            {
                double result = proxy.TradeSecurity("IBM", 1000);
                Console.WriteLine("Cost was " + result);
                Console.WriteLine("\nTrade MSFT");
                result = proxy.TradeSecurity("MSFT", 2000);
                Console.WriteLine("Cost was " + result);
            }
            catch (Exception ex)
            {
                Console.Write("Can not perform task. Error Message - " + ex.Message);
            }
            Console.WriteLine("\n\nPress <enter> to exit...");
            Console.ReadLine();
        }
    }
}
