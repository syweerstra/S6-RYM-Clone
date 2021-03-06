using MusicService;
using Microsoft.EntityFrameworkCore;
using RabbitMQLibrary;
using MusicService.Repositories;
using MassTransit;
using MusicService.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.s

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddMessageProducing("MusicService");


builder.Services.AddTransient<IAlbumRepository, AlbumRepository>();
builder.Services.AddTransient<IImageStorage, AzureBlobStorage>();
builder.Services.AddTransient<SqlContext>();

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
    config.AddConsumer<RatingConsumer>();
    config.AddConsumer<UserDeletedConsumer>();

    config.UsingRabbitMq((context, config) =>
    {
        //config.Host("amqp://guest:guest@localhost:5672");

        config.Host("rabbitmq-service", 5672, "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        config.ReceiveEndpoint("rating-queue", c =>
        {
            c.ConfigureConsumer<RatingConsumer>(context);
        });
        config.ReceiveEndpoint("delete-rating-queue", c =>
        {
            c.ConfigureConsumer<UserDeletedConsumer>(context);
        });
    });
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

app.MapControllers();

app.Run();
