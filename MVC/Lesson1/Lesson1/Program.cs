using Lesson1;
using System.Net;
using System.Text;

#region

//HttpListener listener = new ();
//listener.Prefixes.Add("http://localhost:27001/");
//listener.Start ();
//Console.WriteLine("I am listening...");

//while (true)
//{
//    HttpListenerContext context=listener.GetContext();
//    Console.WriteLine("Request handler");
//    context.Response.OutputStream.Write(Encoding.UTF8.GetBytes("hello world"));
//    context.Response.Close();
//}
#endregion

WebHost webHost = new(27001);
webHost.Run();

