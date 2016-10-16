using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace PracticalWcf
{
    [ServiceContract()]
    public interface IFileService
    {
        [OperationContract
          (ProtectionLevel=System.Net.Security.ProtectionLevel.None)]
        byte[] GetFile( string fileName );
    }


    public class FileService : IFileService
    {

        public byte[] GetFile( string fileName )
        {
            byte[] result = File.ReadAllBytes( 
                Path.Combine( 
                    AppDomain.CurrentDomain.BaseDirectory, 
                    fileName) );
            Console.WriteLine( "Request for file " + fileName );
            return result;
        }
    }

}
