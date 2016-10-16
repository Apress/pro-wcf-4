using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace ExchangeService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Uri address = new Uri("http://localhost:8001/TradeService");
            WSHttpBinding binding = new WSHttpBinding();
            Type contract = typeof(ExchangeService.ITradeService);
            ServiceHost host = new ServiceHost(typeof(TradeService));
            host.AddServiceEndpoint(contract, binding, address);

            // Add Auditing to the service
            ServiceSecurityAuditBehavior auditProvider = 
                host.Description.Behaviors.Find<ServiceSecurityAuditBehavior>();
            if (auditProvider == null)
            {
                auditProvider = new ServiceSecurityAuditBehavior();
            }
            auditProvider.AuditLogLocation = AuditLogLocation.Application;
            auditProvider.MessageAuthenticationAuditLevel = 
                AuditLevel.SuccessOrFailure;
            auditProvider.ServiceAuthorizationAuditLevel = 
                AuditLevel.SuccessOrFailure;
            host.Description.Behaviors.Add(auditProvider);
            host.Open();
            Console.WriteLine("The WCF Management trading service is available.");
            Console.ReadKey();
        }
    }
}
