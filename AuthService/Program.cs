using AuthService;
using AuthService.Data;
using IdentityServer4.Models;
using IdentityServer4.Test;
using MassTransit;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<SqlContext>();


// For Identity
builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<DeleteUserConsumer>();
    config.UsingRabbitMq((context, config) =>
    {
        //config.Host("amqp://guest:guest@172.17.0.2:5672");
        // config.Host("amqp://guest:guest@localhost:5672");
        //config.Host("amqp://guest:guest@rabbitmq");

        config.Host("rabbitmq-service", 5672, "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        config.ReceiveEndpoint("delete-user-queue", c =>
        {
            c.ConfigureConsumer<DeleteUserConsumer>(context);
        });
    });
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 3;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
}).AddEntityFrameworkStores<SqlContext>().AddDefaultTokenProviders();

// Adding Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
});

// For JWT
//builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JWT"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCookiePolicy();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
