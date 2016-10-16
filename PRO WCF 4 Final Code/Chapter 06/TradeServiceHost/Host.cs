using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace ExchangeService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(TradeService), new Uri[] { new Uri("http://localhost:8000/") }))
            {
                host.Open();
                Console.WriteLine("The WCF Management trading service is available.");
                Console.ReadKey();
            }
        }
    }
}
