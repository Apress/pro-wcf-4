// Note that this class is not used in the solution
using System;
using System.ServiceModel;

namespace QuickReturns.StockTrading.ExchangeService.MessageContracts
{
    [MessageContract]
    public class QuoteMessage
    {
        [MessageBodyMember]
        public string Ticker;

        [MessageBodyMember]
        public decimal Bid;

        [MessageBodyMember]
        public decimal Ask;

        [MessageHeader]
        public string Publisher;

        [MessageBodyMember]
        private DateTime UpdateDateTime;
    }
}
