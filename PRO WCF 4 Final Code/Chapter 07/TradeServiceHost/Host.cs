using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Security.Cryptography.X509Certificates;

namespace ExchangeService
{
    public class Program
    {
        public static void Main(string[] args)
        {
                Uri address = new Uri("https://localhost:8001/TradeService");
                WSHttpBinding binding = new WSHttpBinding();
                // Set the security mode
                binding.Security.Mode = SecurityMode.TransportWithMessageCredential;
                binding.Security.Message.ClientCredentialType =  
                    MessageCredentialType.Certificate;
    
                Type contract = typeof(ExchangeService.ITradeService);
                ServiceHost host = new ServiceHost(typeof(TradeService));
                host.AddServiceEndpoint(contract, binding, address);
                //Set the service certificate.
                //host.Credentials.ServiceCertificate.SetCertificate(
                //    StoreLocation.CurrentUser,
                //    StoreName.My,
                //    X509FindType.FindBySubjectName,
                //    "localhost");
                host.Open();
                Console.WriteLine("The WCF Management trading service is available.");
                Console.ReadKey();
        }
    }
}
