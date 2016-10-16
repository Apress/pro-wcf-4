// Note that this class is not used in the solution
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace QuickReturns.StockTrading.ExchangeService.Contracts
{
    [ServiceContract(Namespace = "http://QuickReturns")]
    interface ITradeServiceMessage
    {
        [OperationContract()]
        Message GetQuote(string ticker);

        [OperationContract()]
        void PublishQuote(Message quote);
    }
}
