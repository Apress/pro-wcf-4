using System;
using System.ServiceModel;

namespace ExchangeService
{
    [ServiceContract(
        Namespace = "http://PracticalWcf",
        Name = "TradeService",
        SessionMode = SessionMode.Required
        )
    ]
    public interface ITradeService
    {
        [OperationContract( 
          Action="http://PracticalWcf/TradeSecurityNow",
          IsOneWay = false,
          IsTerminating = false,
          Name = "TradeSecurityNow"
          )]
        decimal TradeSecurity(string ticker, int quantity);
    }

    public class TradeService : ITradeService
    {
        const decimal IBM_Price = 80.50m;
        const decimal MSFT_Price = 30.25m;
        public decimal TradeSecurity(string ticker, int quantity)
        {
            if( quantity < 1 )
                throw new ArgumentException(
                    "Invalid quantity", "quantity" );
            switch( ticker.ToLower() )
            {
                case "ibm":
                    return quantity * IBM_Price;
                case "msft":
                    return quantity * MSFT_Price;
                default:
                    throw new ArgumentException(
                        "Don't know - only MSFT & IBM", "ticker" );
            }
        }


        public decimal Nada(string m)
        {
            return 1m;
        }
    }
}