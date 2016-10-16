using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Client
{
    [ServiceContract(SessionMode = SessionMode.Required)]

    public interface ITradeService
    {
        [OperationContract]
        string BeginTrade();
        [OperationContract]
        void AddTrade(Trade trade);
        [OperationContract]
        void AddFunct(string funct);
        [OperationContract]
        Decimal DoCalc();
        [OperationContract]
        void Buy();
        [OperationContract]
        void EndTrade();
    }
}