using System;
using System.Collections.Generic;
using System.Text;

namespace WcfClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ExchangeService.TradeServiceClient proxy = new ExchangeService.TradeServiceClient())
            {
                Console.WriteLine("\nTrade IBM");
                decimal result = proxy.TradeSecurityAtMarket( MakeTrade("IBM", 1000));
                Console.WriteLine("Cost was " + result);

                Console.WriteLine("\nTrade MSFT");
                result = proxy.TradeSecurityAtMarket(MakeTrade("MSFT", 2000));
                Console.WriteLine("Cost was " + result);

                try
                {
                    Console.WriteLine("\nTrade ATT");
                    result = proxy.TradeSecurityAtMarket(MakeTrade("T", 3000));
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

        static ExchangeService.Trade MakeTrade(string ticker, int quantity)
        {
            ExchangeService.Trade trade = new ExchangeService.Trade();
            trade.Quantity = quantity;
            trade.Ticker = ticker;
            return trade;
        }
    }
}
