using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;

namespace WcfHost
{
    class Program
    {
        static void Main( string[] args )
        {
            try
            {
                MyServiceHost.StartService();
                Console.WriteLine( "Press enter to end host..." );
                Console.ReadLine();
                MyServiceHost.StopService();
            }
            catch( Exception ex )
            {
                Console.WriteLine( ex.Message );
                Console.WriteLine( "Press enter to end host..." );
                Console.ReadLine();
            }
            
        }
    }

    internal class MyServiceHost
    {
        internal static ServiceHost myServiceHost = null;

        internal static void StartService()
        {
            //Consider putting the baseAddress in the configuration system
            //and getting it here with AppSettings
            Uri baseAddress = new Uri( "http://localhost:8080/FileService" );
            //Instantiate new ServiceHost 
            myServiceHost = new ServiceHost( typeof( PracticalWcf.FileService ), baseAddress );
            

            //The following for programatic addition
            //WSHttpBinding wsBinding = new WSHttpBinding();
            //wsBinding.MessageEncoding = WSMessageEncoding.Mtom;
            //myServiceHost.AddServiceEndpoint(
            //    typeof( MtomSvc.IMtomSample ),
            //    wsBinding,
            //    baseAddress );

            //the following for programatic addition of Basic Profile 1.1
            //BasicHttpBinding binding = new BasicHttpBinding();
            //myServiceHost.AddServiceEndpoint(
            //    typeof( MyService,
            //    binding,
            //    baseAddress);


            //Open myServiceHost
            myServiceHost.Open();
        }

        internal static void StopService()
        {
            //Call StopService from your shutdown logic (i.e. dispose method)
            if( myServiceHost.State != CommunicationState.Closed )
                myServiceHost.Close();
        }
    }

}
