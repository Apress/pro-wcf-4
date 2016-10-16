using System;
using System.ServiceModel;

namespace ExchangeService
{
    [ServiceContract(
        Namespace = "http://PracticalWcf/Exchange",
        Name = "TradeService"
        )
    ]
    public interface ITradeService
    {
        [OperationContract(
            Action = "http://PracticalWcf/Exchange/TradeService/TradeSecurityAtMarket"
        )]
        [FaultContract( typeof( ArgumentException ) )] 
        TradeSecurityResponse TradeSecurity( TradeSecurityRequest tradeRequest );
    }


    /// <summary>
    /// TradeService Implementation of ITradeService 
    /// for the Exchange
    /// </summary>
    public class TradeService : ITradeService
    {
        const decimal IBM_Price = 80.50m;
        const decimal MSFT_Price = 30.25m;
        public TradeSecurityResponse TradeSecurity( TradeSecurityRequest trade )
        {
            try
            {
                //Embedded rules
                if( trade.Participant != "ABC" )
                    throw new ArgumentException( "Particpant must be \"ABC\"" );

                if( trade.Publisher != "XYZ" )
                    throw new ArgumentException( "Publisher must be \"XYZ\"" );
                
                if( trade.Ticker != "MSFT" )
                    throw new ArgumentException( "Ticker must be \"MSFT\"" );
                

                //Quantity check
                if( trade.TradeItem.Quantity < 1 )
                    throw new ArgumentException( "Bad Quantity on Trade" );

                Execution execution = null;

                switch( trade.TradeItem.Ticker.ToLower() )
                {
                    case "ibm":
                        execution = ExecuteTrade( trade.TradeItem, IBM_Price );
                        break;
                    case "msft":
                        execution = ExecuteTrade( trade.TradeItem, MSFT_Price );
                        break;
                    default:
                        throw new ArgumentException(
                            "Don't know - only MSFT & IBM", "ticker" );
                }

                TradeSecurityResponse response = new TradeSecurityResponse();
                response.ExecutionReport = execution;
                return response;
            }
            catch( ArgumentException ex )
            {
                throw new FaultException<ArgumentException>( ex );
            }
        }


        /// <summary>
        /// Utility method populates an execution
        /// </summary>
        /// <param name="trade">trade object inbound</param>
        /// <param name="price">market price to use</param>
        /// <returns></returns>
        private Execution ExecuteTrade( Trade trade, decimal price )
        {
            trade.TradeTime = DateTime.Now.ToUniversalTime();
            trade.ExecutionAmount = trade.Quantity * price;
            if( trade.Type.ToString().ToLower() == "s" )
                trade.ExecutionAmount *= -1;

            Execution exec = new Execution( trade );
            exec.ExecutionAmount = trade.ExecutionAmount;

            return exec;
        }

    }
}