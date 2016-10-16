using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace ExchangeService
{
    [DataContract(
        Namespace = "http://PracticalWcf/Exchange/Trade")]
    public class Trade
    {
        string _ticker;
        char _type;
        string _publisher;

        [DataMember(
            Name = "Participant", IsRequired = true, Order = 0)]
        string _participant;

        [DataMember(
            Name = "QuotedPrice", IsRequired = false, Order = 1)]
        internal decimal _quotedPrice;

        [DataMember(
            Name = "Quantity", IsRequired = true, Order = 1)]
        private int _quantity;

        [DataMember(
            Name = "TradeTime", IsRequired = false, Order = 9)]
        Nullable<DateTime> _tradeTime;

        decimal _executionAmount;

        /// <summary>
        /// Primary exchange security identifier
        /// </summary>
        [DataMember(IsRequired = true, Order = 3)]
        public string Ticker
        {
            get { return _ticker; }
            set { _ticker = value; }
        }

        /// <summary>
        /// B or S for Buy or Sell
        /// </summary>
        [DataMember(IsRequired = true, Order = 4)]
        public char Type
        {
            get { return _type; }
            set { _type = value; }
        }

        /// <summary>
        /// Identifier of publisher
        /// </summary>
        [DataMember(IsRequired = true, Order = 10)]
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
        public Nullable<DateTime> TradeTime
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
