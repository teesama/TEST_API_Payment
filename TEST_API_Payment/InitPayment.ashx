<%@ WebHandler Language="C#" Class="InitPayment" %>

using System;
using System.Web;

public class InitPayment : Webbase, IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Response.Write("Hello World");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}