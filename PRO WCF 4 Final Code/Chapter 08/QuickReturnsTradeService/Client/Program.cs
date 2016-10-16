using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Press any key when the  tradeservice is ready.");
            Console.ReadKey();
            ITradeService tradeProxy = new ChannelFactory<ITradeService>("TradeServiceConfiguration").CreateChannel();
            tradeProxy.BeginTrade();
            Trade trade = new Trade();
            trade.Amount = 100;
            trade.Symbol = "ABCX";
            trade.Date = DateTime.Now.AddMonths(1);
            tradeProxy.AddTrade(trade);
            tradeProxy.AddFunct("TradeEstimate");
            tradeProxy.AddFunct("StockEstimate");
            decimal tradeValue = tradeProxy.DoCalc();
            Console.WriteLine(string.Format("Deal value estimated at ${0}", tradeValue));
            tradeProxy.Buy();
            tradeProxy.EndTrade();

            Console.WriteLine();
            Console.WriteLine("Completed");
            Console.ReadKey();
        }
    }
}