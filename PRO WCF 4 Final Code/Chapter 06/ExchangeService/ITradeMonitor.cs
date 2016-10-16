using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace ExchangeService
{
    [ServiceContract]
    public interface ITradeMonitor
    {
        [OperationContract]
        string StartMonitoring(string ticker);
        [OperationContract]
        string StopMonitoring(string ticker);
    }
}
