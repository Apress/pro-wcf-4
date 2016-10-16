using System;
using System.Collections.Generic;
using System.Text;
using SimpleClientWithProxy.ExchangeService;

namespace SimpleClientWithProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            TradeServiceClient proxy = new TradeServiceClient();

            Quote msftQuote = new Quote();
            msftQuote.Ticker = "MSFT";
            msftQuote.Bid = 30.25M;
            msftQuote.Ask = 32.00M;
            msftQuote.Publisher = "PracticalWCF";

            Quote ibmQuote = new Quote();
            ibmQuote.Ticker = "IBM";
            ibmQuote.Bid = 80.50M;
            ibmQuote.Ask = 81.00M;
            ibmQuote.Publisher = "PracticalWCF";

            proxy.PublishQuote(msftQuote);
            proxy.PublishQuote(ibmQuote);

            Quote result;
            result = proxy.GetQuote("MSFT");
            Console.WriteLine("Ticker: {0} Ask: {1} Bid: {2}",
                result.Ticker, result.Ask, result.Bid);

            result = proxy.GetQuote("IBM");
            Console.WriteLine("Ticker: {0} Ask: {1} Bid: {2}",
                result.Ticker, result.Ask, result.Bid);

            try
            {
                result = proxy.GetQuote("ATT");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (result == null)
            {
                Console.WriteLine("Ticker ATT not found!");
            }

            Console.WriteLine("Done! Press return to exit");
            Console.ReadLine();
        }
    }
}
