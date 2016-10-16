using System;
using System.Collections.Generic;
using System.Text;

namespace VB6ComClient
{
    class Program
    {
        static void Main( string[] args )
        {
            OldHorse._PositionManagementClient proxy = new VB6ComClient.OldHorse._PositionManagementClient();

            int q = proxy.GetQuantity( "MSFT" );
            Console.WriteLine( "We have " + q + " of MSFT" );
            q = proxy.UpdatePosition( "MSFT", 100 );
            Console.WriteLine( "We now have " + q + " of MSFT" );
            proxy.Close();
            proxy = null;
            Console.WriteLine("Press return to end..." );
            Console.ReadLine();

            
        }
    }
}
