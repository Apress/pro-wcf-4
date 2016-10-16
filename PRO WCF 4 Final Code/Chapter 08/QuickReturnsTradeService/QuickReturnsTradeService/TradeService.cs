using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace QuickReturns
{
    //Sets the concurrency mode to per session and single
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Single)]

    public class TradeService : ITradeService
    {
        #region ITradeService Members
        string ITradeService.BeginTrade()
        {
            {
                string tradeID = Guid.NewGuid().ToString();
                OperationContext.Current.InstanceContext.Extensions.Add(new TradeData(tradeID));
                Console.WriteLine(string.Format("Started Trade {0}", tradeID));
                return tradeID;
            }
        }
        void ITradeService.AddTrade(Trade trade)
        {
            TradeData tradeData = OperationContext.Current.InstanceContext.Extensions.Find<TradeData>();
            tradeData.AddTrade(trade);
            Console.WriteLine(string.Format("Added trade for{0}", trade));

        }
        void ITradeService.AddFunct(string funct)
        {
            Console.WriteLine(string.Format("Added function {0}", funct));
        }
        decimal ITradeService.DoCalc()
        {
            Decimal value = DateTime.Now.Millisecond / 10;
            Console.WriteLine(string.Format("Calculated value as {0}", value));
            return value;
        }
        void ITradeService.Buy()
        {
            TradeData tradeData = OperationContext.Current.InstanceContext.Extensions.Find<TradeData>();
            foreach (Trade trade in tradeData.Trades)
            {
                Console.WriteLine(string.Format("Bought {0}", trade));
            }
        }
        void ITradeService.EndTrade()
        {
            TradeData tradeData = OperationContext.Current.InstanceContext.Extensions.Find<TradeData>();
            Console.WriteLine(string.Format("Completed Trade: {0}", tradeData.TradeID));
        }
        #endregion
    }
    public class TradeData : IExtension<InstanceContext>
    {
        private string tradeID = null;
        private Trade[] trades = null;
        public TradeData(string tradeID)
        {
            this.tradeID = tradeID;
            this.trades = new Trade[] { };
        }
        public string TradeID
        {
            get
            {
                return this.tradeID;
            }
        }
        public void AddTrade(Trade trade)
        {
            List<Trade> tradeList = null;
            tradeList = new List<Trade>(this.trades);
            tradeList.Add(trade);
            this.trades = tradeList.ToArray();

        }
        public Trade[] Trades
        {
            get
            {
                return this.trades;
            }
        }
        #region IExtension<InstanceContext> Members
        void IExtension<InstanceContext>.Attach(InstanceContext owner)
        {
        }
        void IExtension<InstanceContext>.Detach(InstanceContext owner)
        {
        }
        #endregion
    }
}

