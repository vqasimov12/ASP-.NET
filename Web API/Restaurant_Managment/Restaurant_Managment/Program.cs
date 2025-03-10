using Application;
using DAL.SqlServer;
using Microsoft.OpenApi.Models;
using RestaurantManagement.Middlewares;
using RestaurantManagment.Middlewares;
using RestaurantManagment.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Please enter valid token here ",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
      {
        {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
              }
            },
            new List<string>()
          }
        });
});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddAuthenticationService (builder.Configuration);

//builder.Services.ConfigureCors();


var conn = builder.Configuration.GetConnectionString("myconn");
builder.Services.AddSqlServerServices(conn);

builder.Services.AddApplicationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseMiddleware<CorsMiddleware>();
app.UseCors();
//app.UseMiddleware<RateLimitMiddleware>(2,TimeSpan.FromMinutes(1));


app.MapControllers();

app.Run();