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
        [OperationContract(ProtectionLevel=System.Net.Security.ProtectionLevel.None)]
        byte[] GetFile( string fileName );
    }

    public class FileService : IFileService
    {
        public byte[] GetFile( string fileName )
        {
            byte[] result = File.ReadAllBytes( Path.Combine( AppDomain.CurrentDomain.BaseDirectory, fileName) );
            return result;
        
        }
    }

    //[DataContract]
    //public class DataContract1
    //{
    //    public enum ContentType : int { Jpg = 0, Text }
    //    byte[] content;
    //    ContentType fileType;

    //    [DataMember]
    //    public byte[] Content
    //    {
    //        get { return content; }
    //        set { content = value; }
    //    }
    //    [DataMember]
    //    public ContentType FileType
    //    {
    //        get { return fileType; }
    //        set { fileType = value; }
    //    }
    //}
}
