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
                Console.WriteLine( "wait for Server - Press <Enter> to continue..." );
                Console.ReadLine();

                Console.WriteLine("\nTrade IBM");
                decimal result = proxy.TradeSecurityNow("IBM", 1000);
                Console.WriteLine("Cost was " + result);

                Console.WriteLine("\nTrade MSFT");
                result = proxy.TradeSecurityNow("MSFT", 2000);
                Console.WriteLine("Cost was " + result);

                try
                {
                    Console.WriteLine("\nTrade ATT");
                    result = proxy.TradeSecurityNow("T", 3000);
                    Console.WriteLine("Cost was " + result);
                }
                catch (Exception ex)
                {
                    Console.Write("Exception was: " + ex.Message);
                }

                Console.WriteLine("Can't use this proxy anymore as it's had a fault");
                Console.WriteLine("You will now see an exception appear");
                Console.WriteLine("\n\nPress <enter> to exit...");
                Console.ReadLine();

                proxy.Close();

            }
        }
    }
}
