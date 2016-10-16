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
        [OperationContract(
          ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign)]
        string SayHello( string name );
    }


    public class FileService : IFileService
    {

        public string SayHello( string name )
        {
            return "Hello from WCF - " + name;

        }

    }

}
