using System;
using System.EnterpriseServices;
using System.Runtime.InteropServices;

namespace OldHorse2
{

    [Guid( "3B26F4CA-E839-4ab6-86D4-AADB0A8AADA5" )]
    public interface IPositionManagement
    {
        long UpdatePosition( string ticker, long quantity );
        long GetQuantity( string ticker );
    }

    [Guid( "08F01AD6-F3EB-4f41-A73A-270AA942881A" )]
    [Transaction(TransactionOption.Required)]
    public class PositionManagement : ServicedComponent, IPositionManagement
    {
        public PositionManagement() {}

        #region IPositionManagement Members

        [AutoComplete]
        public long UpdatePosition( string ticker, long quantity )
        {
            IPosition pos = new Position();
            pos = pos.GetPosition( ticker );
            pos.Quantity += quantity;
            return pos.Quantity;
        }

        [AutoComplete]
        public long GetQuantity( string ticker )
        {
            IPosition pos = new Position();
            pos = pos.GetPosition( ticker );
            return pos.Quantity;
        }

        #endregion
    }
}
