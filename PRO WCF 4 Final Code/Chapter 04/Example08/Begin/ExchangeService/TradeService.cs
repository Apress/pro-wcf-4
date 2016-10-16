using System;
using System.ServiceModel;

namespace ExchangeService
{
    [ServiceContract(
        Namespace = "http://PracticalWcf/Exchange/TradeService",
        Name = "TradeService",
        SessionMode = SessionMode.Required)
    ]
    [XmlSerializerFormat(
        Style = OperationFormatStyle.Document,
        Use = OperationFormatUse.Literal)]
    public interface ITradeService
    {
        [OperationContract(
          IsOneWay = false,
          Name = "TradeSecurityAtMarket"
          )]
        decimal TradeSecurity(Trade trade);
    }

    public class TradeService : ITradeService
    {
        const decimal IBM_Price = 80.50m;
        const decimal MSFT_Price = 30.25m;
        public decimal TradeSecurity(Trade trade)
        {
            if( trade.Quantity < 1 )
                throw new ArgumentException(
                    "Invalid quantity", "quantity" );

            switch( trade.Ticker.ToLower() )
            {
                case "ibm":
                    ExecuteTrade( trade, IBM_Price );
                    break;
                case "msft":
                    ExecuteTrade( trade, MSFT_Price );
                    break;
                default:
                    throw new ArgumentException(
                        "Don't know - only MSFT & IBM", "ticker" );
            }

            return trade.ExecutionAmount;
        }

        private void ExecuteTrade( Trade trade, decimal price )
        {
            trade.TradeTime = DateTime.Now.ToUniversalTime();
            trade.ExecutionAmount = trade.Quantity * price;

            if( trade.Type.ToString().ToLower() == "s" )
                trade.ExecutionAmount *= -1;
           
        }
    }
}