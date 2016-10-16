using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace ExchangeService
{

    [DataContract(
        Namespace = "http://PracticalWcf/Exchange/Execution" )]
    public class Execution
    {
        [DataMember(Name= "SettleDate")]
        DateTime _settlementDate;

        [DataMember( Name = "Participant" )]
        string _participant;

        [DataMember( Name = "ExecutionAmount" )]
        decimal _executionAmount;

        [DataMember( Name = "TradeSubmitted" )]
        Trade _trade;


        public Execution( Trade trade )
        {
            _trade = trade;
            _participant = trade.Participant;
            _settlementDate = DateTime.Now.ToUniversalTime();
        }

        public DateTime SettlementDate
        {
            get { return _settlementDate; }
            set { _settlementDate = value; }
        }
        public string Participant
        {
            get { return _participant; }
            set { _participant = value; }
        }
        public decimal ExecutionAmount
        {
            get { return _executionAmount; }
            set { _executionAmount = value; }
        }
        public Trade Trade
        {
            get { return _trade; }
            set { _trade = value; }
        }
    }
}
