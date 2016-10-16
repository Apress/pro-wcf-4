using System;
using System.ServiceModel;
using System.Runtime.Serialization;

// A WinFX service consists of a contract (defined below as IMyService, DataContract1), 
// a class which implements that interface (see MyService), 
// and configuration entries that specify behaviors associated with 
// that implementation (see <system.serviceModel> in web.config)

[ServiceContract()]
public interface IMyService
{
    [OperationContract]
    string MyOperation1(string myValue1);
    [OperationContract]
    string MyOperation2(DataContract1 dataContractValue);
}

public class MyService : IMyService
{
    public string MyOperation1(string myValue1) 
    {
        return "Hello: " + myValue1;
    }
    public string MyOperation2(DataContract1 dataContractValue)
    {
        return "Hello: " + dataContractValue.FirstName + " " + dataContractValue.LastName;
    }
}

[DataContract]
public class DataContract1
{
    string firstName;
    string lastName;

    [DataMember]
    public string FirstName
    {
        get { return firstName;}
        set { firstName = value;}
    }
    [DataMember]
    public string LastName
    {
        get { return lastName;}
        set { lastName = value;}
    }
}

