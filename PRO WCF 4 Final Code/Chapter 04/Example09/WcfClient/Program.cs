using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;

namespace WcfClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (ExchangeService.TradeServiceClient proxy = new ExchangeService.TradeServiceClient())
                {
                    Console.WriteLine("\nTrade MSFT");
                    ExchangeService.Trade trade1 = MakeTrade("MSFT", 2000);
                    ExchangeService.Execution execution =
                        proxy.TradeSecurity(
                            trade1.Participant,
                            trade1.Publisher,
                            trade1.Ticker,
                            trade1);

                    Console.WriteLine("Cost was " + execution.ExecutionAmount);
                }
            }
            catch (FaultException<ArgumentException> ex)
            {
                Console.WriteLine("ArgumentException Occured");
                Console.WriteLine("\tAction:\t" + ex.Action);
                Console.WriteLine("\tName:\t" + ex.Code.Name);
                Console.WriteLine("\tMessage:\t" + ex.Detail.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Exception");
                Console.WriteLine('\t' + ex.Message);
            }
            Console.WriteLine("\n\nPress <enter> to exit...");
            Console.ReadLine();

        }


        static ExchangeService.Trade MakeTrade(string ticker, int quantity)
        {
            ExchangeService.Trade trade = new ExchangeService.Trade();
            trade.Participant= "ABC";
            trade.Publisher= "XYZ";
            trade.Quantity= quantity;
            trade.Ticker= ticker;
            trade.Type= 'b';
            return trade;
        }
    }
}
