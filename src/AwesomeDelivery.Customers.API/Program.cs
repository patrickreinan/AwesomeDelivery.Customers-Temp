using AwesomeDelivery.Customers.API;
using AwesomeDelivery.Customers.Application;
using AwesomeDelivery.Customers.Application.Services;
using AwesomeDelivery.Customers.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using patrickreinan_aspnet_logging;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddInfrastructure()
    .AddApplication();
    
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICustomerService, CustomerServiceDecorator>();

builder.Services.AddLogging(c =>
{

    c.AddPRConsoleLogger(() =>
    new PRLoggerConfiguration(LogLevel.Information)

    );


});



var app = builder.Build();



app.MapControllers(); //3

if (app.Environment.IsDevelopment()) //4
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async (context,next) =>
{
    const string X_CORRELATION_ID_HEADER = "x-correlation-id";

    if (context.Request.Headers.ContainsKey(X_CORRELATION_ID_HEADER))
        context.Response.Headers.Add(X_CORRELATION_ID_HEADER, context.Request.Headers[X_CORRELATION_ID_HEADER].First());

    
    await next.Invoke();
});


app.UsePRLogging(nameof(Program));



app.Run();

