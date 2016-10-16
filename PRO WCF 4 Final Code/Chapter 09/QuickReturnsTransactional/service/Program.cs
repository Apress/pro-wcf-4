using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Configuration;

namespace QuickReturns
{
    class Program
    {
        public static void Main()
        {
            using (ServiceHost host = new ServiceHost(typeof(TradeService)))
            {
                host.Open();
                Console.WriteLine("Trade Service in Now Running");
                Console.WriteLine();
                Console.WriteLine("Press ENTER to terminate the service.");
                Console.ReadLine();
            }
        }
    }
}
