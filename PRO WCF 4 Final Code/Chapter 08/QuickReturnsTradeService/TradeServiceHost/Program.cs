using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Configuration;

namespace QuickReturns
{
    public class Program
    {

        public static void Main()
        {
            // Get base address from app settings in configuration
            Uri baseAddress = new Uri(ConfigurationManager.AppSettings["baseAddress"]);

            // Create a ServiceHost for the TradeService type.
            using (ServiceHost serviceHost = new ServiceHost(typeof(TradeService), baseAddress))
            {
                // Open the ServiceHost  and start listening for messages.
                serviceHost.Open();

                // The service can now be accessed.
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                // Close the ServiceHost to shutdown the service.
                serviceHost.Close();
            }
        }
    }
}

