using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Client
{
    [DataContract(Namespace = "QuickReturns", Name = "Trade")]
    public class Trade
    {
        [DataMember]
        public string Symbol;
        [DataMember]
        public long Amount;
        [DataMember]
        public DateTime Date;
    }
}


