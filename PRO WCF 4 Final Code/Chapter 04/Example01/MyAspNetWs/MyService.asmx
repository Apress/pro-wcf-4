<%@ WebService Language="C#" Class="MyService" %>
using System.Web.Services;

[WebService]
public class MyService : System.Web.Services.WebService
{

    [WebMethod]
    public string HelloWorld( string yourName )
    {
        return "Hello, World to " + yourName;
    }
}

