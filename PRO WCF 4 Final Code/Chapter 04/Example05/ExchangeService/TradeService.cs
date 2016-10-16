using System;
using System.ServiceModel;

namespace ExchangeService
{
    [ServiceContract(
        Namespace = "http://PracticalWcf/Exchange/TradeService",
        Name = "TradeService")
    ]
    public interface ITradeService
    {
        [OperationContract]
        decimal TradeSecurity(string ticker, int quantity);
    }
    public class TradeService : ITradeService
    {
        const decimal IBM_Price = 80.50m;
        const decimal MSFT_Price = 30.25m;
        public decimal TradeSecurity(string ticker, int quantity)
        {
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
    }
}