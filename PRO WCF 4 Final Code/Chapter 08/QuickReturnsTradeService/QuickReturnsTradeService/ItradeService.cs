using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;

namespace QuickReturns
{
    [ServiceContract(SessionMode = SessionMode.Required, Namespace = "http://localhost:8000/TradeService")]
    //[BindingRequirements(RequireOrderedDelivery=true)]
    public interface ITradeService
    {
        [OperationContract]
        string BeginTrade();
        [OperationContract]
        void AddTrade(Trade trade);
        [OperationContract]
        void AddFunct(string funct);

        [OperationContract]
        decimal DoCalc();
        [OperationContract]
        void Buy();
        [OperationContract]
        void EndTrade();
    }
}
