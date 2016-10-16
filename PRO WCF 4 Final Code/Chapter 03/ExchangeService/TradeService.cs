using System;
using System.Collections;
using System.ServiceModel;
using System.ServiceModel.Activation;
using QuickReturns.StockTrading.ExchangeService.Contracts;
using QuickReturns.StockTrading.ExchangeService.DataContracts;

namespace QuickReturns.StockTrading.ExchangeService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
                   IncludeExceptionDetailInFaults = true)]
    public class TradeService : ITradeService
    {
        private Hashtable tickers = new Hashtable();
        public Quote GetQuote(string ticker)
        {
            lock (tickers)
            {
                Quote quote = tickers[ticker] as Quote;
                if (quote == null)
                {
                    // Quote doesn't exist.
                    throw new Exception(
                        string.Format("No quotes found for ticker '{0}'",
                            ticker));
                }
                return quote;
            }
        }

        public void PublishQuote(Quote quote)
        {
            lock (tickers)
            {
                Quote storedQuote = tickers[quote.Ticker] as Quote;
                if (storedQuote == null)
                {
                    tickers.Add(quote.Ticker, quote);
                }
                else
                {
                    tickers[quote.Ticker] = quote;
                }
            }
        }
    }
}
