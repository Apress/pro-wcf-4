using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace QuickReturn
{
    [ServiceContract]
    public interface IQuickReturnQuoteService
    {
        [OperationContract]
        StockQuote[] GetPortfolio(string[] portfolioTickers);

        [OperationContract]
        StockQuote GetQuote(string ticker);
    }

    public class QuoteService : IQuickReturnQuoteService
    {
        public StockQuote[] GetPortfolio(string[] portfolioTickers)
        {

            ArrayList tickers = new ArrayList();

            foreach (string stockTicker in portfolioTickers)
            {
                StockQuote stockQuote = new StockQuote(stockTicker);
                tickers.Add(stockQuote);
            }

            return (StockQuote[])tickers.ToArray(typeof(StockQuote));
        }

        public StockQuote GetQuote(string ticker)
        {
            StockQuote quote = new StockQuote(ticker);

            return quote;
        }
    }
}
