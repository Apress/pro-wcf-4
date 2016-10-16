using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeService
{
    [Serializable]
    public class Trade
    {
        string _ticker;
        char _type;
        string _publisher;
        string _participant;
        decimal _quotedPrice;
        int _quantity;
        DateTime _tradeTime;
        decimal _executionAmount;


        /// <summary>
        /// Primary exchange security identifier
        /// </summary>
        public string Ticker
        {
            get { return _ticker; }
            set { _ticker = value; }
        }

        /// <summary>
        /// B or S for Buy or Sell
        /// </summary>
        public char Type
        {
            get { return _type; }
            set { _type = value; }
        }

        /// <summary>
        /// Identifier of publisher
        /// </summary>
        public string Publisher
        {
            get { return _publisher; }
            set { _publisher = value; }
        }

        /// <summary>
        /// Identifier of participant
        /// </summary>
        public string Participant
        {
            get { return _participant; }
            set { _participant = value; }
        }

        /// <summary>
        /// Price from original Quote corresponding to either 
        /// the Bid or Ask when trade is a Sell or 
        /// Buy type respectively.
        /// </summary>
        public decimal QuotedPrice
        {
            get { return _quotedPrice; }
            set { _quotedPrice = value; }
        }

        /// <summary>
        /// Quantity of shares as part of the trade
        /// </summary>
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        /// <summary>
        /// Timestamp in GMT of when the trade 
        /// was requested using the exchange’s 
        /// clock as the master
        /// </summary>
        public DateTime TradeTime
        {
            get { return _tradeTime; }
            set { _tradeTime = value; }
        }

        /// <summary>
        /// Amount of execution
        /// </summary>
        public decimal ExecutionAmount
        {
            get { return _executionAmount; }
            set { _executionAmount = value; }
        }

    }
}
