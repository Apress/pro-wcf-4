﻿


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="ITradeService")]
public interface ITradeService
{
    
    [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ITradeService/TradeQueue")]
    void DoTrade(string BuyStock, string SellStock, int Amount);
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
    
    public TradeServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public TradeServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public void DoTrade(string BuyStock, string SellStock, int Amount)
    {
        base.Channel.DoTrade(BuyStock, SellStock, Amount);
    }
}
