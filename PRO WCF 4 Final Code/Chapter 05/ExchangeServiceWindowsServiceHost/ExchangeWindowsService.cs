using System;
using System.ServiceModel;
using System.ServiceProcess;
using QuickReturns.StockTrading.ExchangeService;

namespace QuickReturns.StockTrading.ExchangeService.Hosts
{
    public partial class ExchangeWindowsService : ServiceBase
    {
        ServiceHost host;

        public ExchangeWindowsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // Uncomment to debug this properly
            // System.Diagnostics.Debugger.Break();
            host = new ServiceHost(typeof(TradeService));
            host.Open();
        }

        protected override void OnStop()
        {
            if (host != null)
                host.Close();
        }
    }
}
