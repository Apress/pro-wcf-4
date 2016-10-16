using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
namespace QuickReturns
{
    [DataContract(Namespace = "QuickReturns", Name = "Trade")]
    public class Trade
    {
        [DataMember]
        public string Symbol;
        [DataMember]
        public long? Amount;
        [DataMember]
        public DateTime? Date;
        public override string ToString()
        {
            string symbol = (this.Symbol != null) ? ((this.Symbol != string.Empty) ? this.Symbol : "?") : "?";
            string date = (this.Date != null) ? this.Date.Value.ToShortDateString() : "?";
            string amount = (this.Amount != null) ? this.Amount.ToString() : "?";
            return string.Format("{0}x{1} on {2}", amount, symbol, date);
        }
    }
}