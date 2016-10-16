using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetComClient
{
    class Program
    {
        static void Main( string[] args )
        {
            OldHorse2.PositionManagementClient proxy =
                new OldHorse2.PositionManagementClient();
            long q = proxy.GetQuantity("MSFT");
            Console.WriteLine( "We have " + q + " of MSFT" );
            q = proxy.UpdatePosition( "MSFT", 100 );
            Console.WriteLine( "We now have " + q + " of MSFT" );
            proxy.Close();
            proxy = null;
            Console.WriteLine( "Press return to end..." );
            Console.ReadLine();

        }
    }
}
