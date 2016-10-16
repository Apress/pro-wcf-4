using System;
using System.ServiceModel;
using System.ServiceModel.ComIntegration;

namespace QuickReturnsQuotes
{
    [ServiceContract]
    public interface IQuoteService
    {
        [OperationContract]
        double GetQuote( string ticker );
    }

    public class QuoteService : IQuoteService
    {
        public double GetQuote ( string ticker )
        {
            switch( ticker.Trim().ToUpper() )
            {
                case "MSFT":
                    return 25L;
                case "IBM":
                    return 98L;
                case "AVND":
                    return 7L;
                default:
                    break;
            }
            return 0;
        }
    }


}