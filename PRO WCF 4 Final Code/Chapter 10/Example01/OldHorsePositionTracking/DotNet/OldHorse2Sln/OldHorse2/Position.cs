using System;
using System.Runtime.InteropServices;
using System.EnterpriseServices;

namespace OldHorse2
{
    [Guid( "D428B97A-13C8-4591-8AC3-5E8622A8C8BE" )]
    public interface IPosition
    {
        long Quantity
        { get; set; }

        string Ticker
        { get; set; }

        long GetQuantity( string ticker );
        IPosition GetPosition( string ticker );
    }

    [Guid( "02FD3A3B-CFCE-4298-8766-438C596002B4" )]
    public class Position : ServicedComponent, IPosition
    {
        long m_Quantity;
        string m_Ticker;
        long m_AvndQ = 1000;
        long m_IbmQ = 100;
        long m_MsftQ = 500;

        #region IPosition Members
        public long Quantity
        {
            get { return m_Quantity;}
            set { m_Quantity = value;}
        }

        public string Ticker
        {
            get { return m_Ticker;}
            set { m_Ticker = value;}
        }

        public long GetQuantity( string ticker )
        {
            string sTicker = ticker.Trim().ToUpper();

            switch( sTicker )
            {
                case "MSFT":
                    return m_MsftQ;
                case "IBM":
                    return m_IbmQ;
                case "AVND":
                    return m_AvndQ;
                default:
                    break;
            }
            return 0;
        }

        public IPosition GetPosition( string ticker )
        {
            IPosition pos = new Position();
            pos.Ticker = ticker.Trim().ToUpper();
            pos.Quantity = pos.GetQuantity(pos.Ticker);
            return pos;
        }
        #endregion
    }
}
