using System;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace QuickReturns.StockTrading.ExchangeService
{
   public class TradeServiceCustomHostFactory : ServiceHostFactory
   {
      protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
      {
         TradeServiceCustomHost customServiceHost = 
            new TradeServiceCustomHost(serviceType, baseAddresses);
         return customServiceHost;
      }
   }

   public class TradeServiceCustomHost : ServiceHost
   {
      public TradeServiceCustomHost(Type serviceType, params Uri[] baseAddresses)
         : base(serviceType, baseAddresses)
      {
      }

      protected override void ApplyConfiguration()
      {
         base.ApplyConfiguration();
      }
   }
}