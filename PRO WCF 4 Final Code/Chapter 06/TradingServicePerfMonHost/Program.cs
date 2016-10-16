using System;
using System.Collections.Generic;
using System.Messaging;
using System.ServiceModel;
using System.Text;

namespace ExchangeService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TradePerfMon trade = new TradePerfMon();
            using (ServiceHost host = new ServiceHost(typeof(TradePerfMon), new Uri[] { new Uri("http://localhost:8000/TradePerfMonService") }))
            {
                host.Open();
                trade.InitializeCounters(host.Description.Endpoints);
                Console.WriteLine("The WCF Management trading service is available.");
                for (int index = 1; index < 225; index++)
                {
                    Console.WriteLine("IBM - traded " + (index + 100) + " shares  for " + trade.TradeSecurity("IBM", (index + 100)) + " dollars");
                    // We are deliberately increasing the tolal voulme of trades to view the difference in the perfomance monitor)
                    Console.WriteLine("MSFT - tradedtrade " + index + " shares for " + trade.TradeSecurity("MSFT", index) + " dollars");
                    System.Threading.Thread.Sleep(1000);
                }

                Console.ReadKey();
            }
        }
    }
}
