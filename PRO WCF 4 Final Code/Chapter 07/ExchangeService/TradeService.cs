using System;
using System.ServiceModel;
using System.Security.Permissions;

namespace ExchangeService
{
    [ServiceContract(
        Namespace = "http://PracticalWcf/Exchange/TradeService",
        Name = "TradeService")
    ]
    public interface ITradeService
    {
        [OperationContract]
        double TradeSecurity(string ticker, int quantity);
    }
    public class TradeService : ITradeService, ITradeMonitor
    {
        const double IBM_Price = 80.50D;
        const double MSFT_Price = 30.25D;

        // Invokers must belong to the Administrator group.
        // Please comment this out if you are running the other examples
        [PrincipalPermission(SecurityAction.Demand,
        Role = "Administrators")]
        public double TradeSecurity(string ticker, int quantity)
        {
            Console.WriteLine("Claim made at " + System.DateTime.Now.TimeOfDay);           
            System.ServiceModel.OperationContext opx;
            opx = OperationContext.Current;
            if (opx != null)
            {
                System.IdentityModel.Policy.AuthorizationContext ctx = 
                    opx.ServiceSecurityContext.AuthorizationContext;
                foreach (System.IdentityModel.Claims.ClaimSet cs in ctx.ClaimSets)
                {
                    Console.WriteLine("Claim Issued by : " + cs.Issuer);
                    foreach (System.IdentityModel.Claims.Claim claim in cs)
                    {
                        Console.WriteLine("Claim Type - " + claim.ClaimType);
                        Console.WriteLine("Claim Resource name - " + claim.Resource);
                        Console.WriteLine("Claim Right - " + claim.Right);
                    }
                }
            }
            if (quantity < 1)
                throw new ArgumentException(
                    "Invalid quantity", "quantity");
            switch (ticker.ToLower())
            {
                case "ibm":
                    return quantity * IBM_Price;
                case "msft":
                    return quantity * MSFT_Price;
                default:
                    throw new ArgumentException(
                        "Don't know - only MSFT & IBM", "ticker");
            }
        }

        // Invokers must belong to the Administrator group.
        [PrincipalPermission(SecurityAction.Demand,
        Role = "CalculatorClients")]
        //public double PlatinumTradeSecurity(string ticker, int quantity)
        //{
        //    return quantity * Platinum_Price;

        //}
        public string StartMonitoring(string ticker)
        {
            lock (this)
            {
                // Start the monitoring process here. I.e. - You can configure
                // This function to start a manual log file or
                // or send information to the event log. For this example we are
                // returning a string to indicate that the monitoring has commenced. 
                return "Monitoring has started for " + ticker;
            }
        }
        public string StopMonitoring(string ticker)
        {
            lock (this)
            {
                // End the monitoring process here. 
                return "Monitoring has finished for " + ticker;
            }
        }
    }
}