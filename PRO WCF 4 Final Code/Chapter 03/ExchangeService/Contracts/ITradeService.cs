using System.ServiceModel;
using QuickReturns.StockTrading.ExchangeService.DataContracts;

namespace QuickReturns.StockTrading.ExchangeService.Contracts
{
    [ServiceContract(Namespace = "http://QuickReturns")]
    public interface ITradeService
    {
        [OperationContract()]
        Quote GetQuote(string ticker);

        [OperationContract()]
        void PublishQuote(Quote quote);
    }
}
