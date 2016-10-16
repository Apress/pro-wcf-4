using System;

namespace WcfClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Example04.MyServiceClient proxy =
                new Example04.MyServiceClient())
            {
                string result = proxy.MyOperation1("Shawn");
                Console.WriteLine("Call to MyOperation1 result");
                Console.WriteLine(result);

                Example04.DataContract1 dc = new Example04.DataContract1();
                dc.FirstName = "Shawn";
                dc.LastName = "Cicoria";
                Console.WriteLine("Call to MyOperation2 result");
                result = proxy.MyOperation2(dc);
                Console.WriteLine(result);

                Console.WriteLine("Press <enter> to exit...");
                Console.ReadLine();
            }
        }
    }
}
