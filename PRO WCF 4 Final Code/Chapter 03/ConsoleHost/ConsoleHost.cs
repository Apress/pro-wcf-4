using System;
using System.ServiceModel;
using QuickReturns.StockTrading.ExchangeService;
using QuickReturns.StockTrading.ExchangeService.Contracts;

namespace QuickReturns.StockTrading.ExchangeService.Hosts
{
    public class ConsoleHost
    {
        /// <summary>
        /// This ConsoleHost uses all three methods used for hosting:
        /// 1) Imperative code
        /// 2) Configuration
        /// 3) A Custom Service Host
        /// Uncomment each section to test out.
        /// Both "Host with config" and "CustomServiceHost" require the configuration in app.config
        /// to be uncommented. For the Host with imperative code you have to comment out the 
        /// configuration!
        /// </summary>
        /// <param name="args"/>
        static void Main(string[] args)
        {
            #region Host with imperative code
            //Uri baseAddress = new Uri
            //    ("http://localhost:8080/QuickReturns");
            //Type serviceType = typeof(TradeService);
            //BasicHttpBinding binding = new BasicHttpBinding();
            //ServiceHost host = new ServiceHost(serviceType, baseAddress);
            //host.Description.Endpoints.Clear();//This line is added for convenience (and allows you to leave the app.config as-is.
            //host.AddServiceEndpoint(typeof(ITradeService), binding, "Exchange");
            #endregion

            #region Host with config
            // Note make sure that config is not commented out
            Type serviceType = typeof(TradeService);
            ServiceHost host = new ServiceHost(serviceType);
            #endregion

            #region CustomServiceHost
            //Uri baseAddress =
            //   new Uri("http://localhost:8080/QuickReturns");
            //CustomServiceHost host =
            //   new CustomServiceHost(typeof(TradeService), baseAddress);
            #endregion

            // Open the defined host
            host.Open();
            Console.WriteLine("Service started: Press Return to exit");
            Console.ReadLine();

        }
    }

    public class CustomServiceHost : ServiceHost
    {
        public CustomServiceHost(Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
        }

        protected override void ApplyConfiguration()
        {
            base.ApplyConfiguration();
            BasicHttpBinding binding = new BasicHttpBinding();
            AddServiceEndpoint(typeof(ITradeService), binding, "Exchange");
        }
    }
}
