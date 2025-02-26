using System.Net;

namespace Lesson1;

public class WebHost
{
    private short _port;
    private HttpListener _listener;
    public WebHost(short port)
    {
        _port = port;

    }

    public void Run()
    {
        _listener = new HttpListener();
        _listener.Prefixes.Add($"http://localhost:{_port}/");
        _listener.Start();
        Console.WriteLine($"Http server started on port {_port} ....");
        while (true)
        {
            HttpListenerContext context = _listener.GetContext();
            Console.WriteLine("Request handler");
            Task.Run(() =>
            {
                HandlerRequest(context);
            });


        }
    }

    private void HandlerRequest(HttpListenerContext context)
    {
        HttpListenerRequest request = context.Request;
        HttpListenerResponse response = context.Response;
        StreamWriter writer = new StreamWriter(response.OutputStream);
        var str = request.RawUrl;
        var path = str.Substring(1);
        if (path == "") 
            path = "/index";
        if (!Path.HasExtension(path))
            path += ".html";
        var filename = "../../../Views/" + path;

        try
        {
            if (File.Exists(filename))
            {
                response.StatusCode = 200;
                response.ContentType = "text/html";
                var text = File.ReadAllText(filename);
                writer.Write(text);
            }
            else
            {
                response.StatusCode = 200;
                var text = File.ReadAllText("../../../Views/404.html");
                writer.Write(text);
            }
        }
        catch (Exception ex)
        {
            response.StatusCode = 500;
            writer.Write(ex.ToString());
        }
        finally { writer.Dispose(); }
    }







}