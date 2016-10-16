using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Runtime.Serialization;

namespace QuickReturns.StockTrading.ExchangeService.Clients
{
    [ServiceContract(Namespace = "http://QuickReturns")]
    interface ITradeService
    {
        [OperationContract()]
        Quote GetQuote(string ticker);

        [OperationContract()]
        void PublishQuote(Quote quote);
    }

    [DataContract(Namespace = "http://QuickReturns", Name = "Quote")]
    public class Quote
    {
        [DataMember(Name = "Ticker")]
        public string Ticker;

        [DataMember(Name = "Bid")]
        public decimal Bid;

        [DataMember(Name = "Ask")]
        public decimal Ask;

        [DataMember(Name = "Publisher")]
        public string Publisher;

        [DataMember(Name = "UpdateDateTime")]
        private DateTime UpdateDateTime;
    }

    class SimpleClient
    {
        static void Main(string[] args)
        {
            EndpointAddress address =
               new EndpointAddress
                    ("http://localhost:8080/QuickReturns/Exchange");
            BasicHttpBinding binding = new BasicHttpBinding();
            IChannelFactory<ITradeService> channelFactory =
               new ChannelFactory<ITradeService>(binding);
            ITradeService proxy = channelFactory.CreateChannel(address);

            Quote msftQuote = new Quote();
            msftQuote.Ticker = "MSFT";
            msftQuote.Bid = 30.25M;
            msftQuote.Ask = 32.00M;
            msftQuote.Publisher = "PracticalWCF";

            Quote ibmQuote = new Quote();
            ibmQuote.Ticker = "IBM";
            ibmQuote.Bid = 80.50M;
            ibmQuote.Ask = 81.00M;
            ibmQuote.Publisher = "PracticalWCF";

            proxy.PublishQuote(msftQuote);
            proxy.PublishQuote(ibmQuote);

            Quote result = null;
            result = proxy.GetQuote("MSFT");
            Console.WriteLine("Ticker: {0} Ask: {1} Bid: {2}",
                result.Ticker, result.Ask, result.Bid);

            result = proxy.GetQuote("IBM");
            Console.WriteLine("Ticker: {0} Ask: {1} Bid: {2}",
                result.Ticker, result.Ask, result.Bid);

            try
            {
                result = proxy.GetQuote("ATT");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (result == null)
            {
                Console.WriteLine("Ticker ATT not found!");
            }

            Console.WriteLine("Done! Press return to exit");
            Console.ReadLine();

        }
    }
}
