using AwesomeDelivery.Customers.Application;
using AwesomeDelivery.Customers.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddInfrastructure()
    .AddApplication();
    
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder
    .Services
    .AddAuthorization()
    .AddAuthentication(obj =>
    {
        obj.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

    }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {


        options.Authority = builder.Configuration["IdentityProvider:Authority"];
        options.IncludeErrorDetails = true;


        options.TokenValidationParameters =
          new Microsoft.IdentityModel.Tokens.TokenValidationParameters
          {
              ValidAudience = builder.Configuration["IdentityProvider:Audience"],
              ValidateIssuer = true,
              ValidIssuer = builder.Configuration["IdentityProvider:Issuer"],
              ValidateIssuerSigningKey = true,
          };


    });

var app = builder.Build();


app.UseAuthentication(); //1

app.UseAuthorization(); //2

app.MapControllers(); //3

if (app.Environment.IsDevelopment()) //4
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.Run();

