namespace Middleware.Middlewares;

public class MyCustomMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        await context.Response.WriteAsync("Custom start ");
        await next(context);
    }
}