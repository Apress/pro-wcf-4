using System;

namespace WcfClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using( Example03.MyInterfaceClient proxy = 
                new Example03.MyInterfaceClient() )
            {
                string result = proxy.HelloWorld("Shawn");
                Console.WriteLine(result);
                Console.WriteLine("Press <enter> to exit...");
                Console.ReadLine();
            }
        }
    }
}
