[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(Namespace="http://QuickReturns", ConfigurationName="ITradeService", SessionMode=System.ServiceModel.SessionMode.Required)]
public interface ITradeService
{



    [System.ServiceModel.OperationContractAttribute(Action = "http://QuickReturns/ITradeService/CalculateTradeValue", ReplyAction = "http://QuickReturns/ITradeService/CalcValueResponse")]
    int CalculateTradeValue(int qty, int price);
    
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface ITradeServiceChannel : ITradeService, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public partial class TradeServiceClient : System.ServiceModel.ClientBase<ITradeService>, ITradeService
{
    
    public TradeServiceClient()
    {
    }
    
    public TradeServiceClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public TradeServiceClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
   
    
    
    public int CalculateTradeValue(int qty, int price)
    {
        return base.Channel.CalculateTradeValue(qty,price);
    }
    
   
}
