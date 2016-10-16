using System;
using System.ServiceModel;

[ServiceContract]
public interface IMyInterface
{
    [OperationContract]
    string HelloWorld(string yourName);
}
public class MyService : IMyInterface
{
    public string HelloWorld(string yourName)
    {
        return "Hello World to " + yourName;
    }
}