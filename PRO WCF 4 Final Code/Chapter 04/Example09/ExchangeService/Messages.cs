using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;

namespace ExchangeService
{
    /// <summary>
    /// TradeSecurity Request Message encapsulating a Trade Request Object
    /// </summary>
    [MessageContract]
    public class TradeSecurityRequest
    {
        Trade _trade;
        string _particpant;
        string _publisher;
        string _ticker;

        /// <summary>
        /// The requestor of the trade
        /// </summary>
        [MessageHeader(MustUnderstand=true)]
        public string Participant
        {
            get
            {
                return _particpant;
            }
            set
            {
                _particpant = value;
            }
        }

        /// <summary>
        /// The Trade Item
        /// </summary>
        //[MessageBody]
        [MessageBodyMember]
        public Trade TradeItem
        {
            get
            {
                return _trade;
            }
            set
            {
                _trade = value;
            }
        }

        /// <summary>
        /// The publisher of the quote the trade is
        /// against
        /// </summary>
        [MessageHeader( MustUnderstand = true )]
        public string Publisher
        {
            get
            {
                return _publisher;
            }
            set
            {
                _publisher = value;
            }
        }

        /// <summary>
        /// The security being traded
        /// </summary>
        [MessageHeader( MustUnderstand = true )]
        public string Ticker
        {
            get
            {
                return _ticker;
            }
            set
            {
                _ticker = value;
            }
        }




    }

    /// <summary>
    /// Simple encapsulation of the Execution
    /// Response
    /// </summary>
    [MessageContract]
    public class TradeSecurityResponse
    {
        [MessageBodyMember]
        public Execution ExecutionReport;
    }


}
