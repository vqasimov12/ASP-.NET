using Middleware.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();

var app = builder.Build();

app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Middleware 1 ");
    await next(context);
});

app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Middleware 2 ");
    await next(context);
    //await context.Response.WriteAsync("Middleware 4 ");
    //await next(context);
});

app.UseMiddleware<MyCustomMiddleware>();

app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Middleware 3 ");
    await next(context);
    //await context.Response.WriteAsync("Middleware 5 ");
});

app.Run();