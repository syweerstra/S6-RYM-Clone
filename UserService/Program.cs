using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UserService;
using UserService.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IUserRepository, MockUserRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy",
        builder =>
        {
            builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
        });
});

builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<UserCreatedConsumer>();
    config.UsingRabbitMq((context, config) =>
    {
        config.Host("amqp://guest:guest@localhost:5672");
        //config.Host("amqp://guest:guest@rabbitmq");

        //config.Host("haroldjcastillo:5672", "/", h =>
        //{
        //    h.Username("guest");
        //    h.Password("guest");
        //});

        config.ReceiveEndpoint("user-created-queue", c =>
        {
            c.ConfigureConsumer<UserCreatedConsumer>(context);
        });
    });
});

var key = Encoding.ASCII.GetBytes("geheimpje geheimpje2 geheimpje3 geheimpje4 geheimpje 5");
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
	.AddJwtBearer(x =>
	{
		x.RequireHttpsMetadata = false;
		x.SaveToken = true;
		x.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = new SymmetricSecurityKey(key),
			ValidateIssuer = false,
			ValidateAudience = false
		};
	});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");
app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
