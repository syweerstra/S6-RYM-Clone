using ArtistService;
using ArtistService.Repositories;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
    config.AddConsumer<AlbumConsumer>();
    config.AddConsumer<UserDeletedConsumer>();


    config.UsingRabbitMq((context, config) =>
    {
        //config.Host("amqp://guest:guest@localhost:5672");

        config.Host("rabbitmq-service", 5672, "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        config.ReceiveEndpoint("album-queue", c =>
        {
            c.ConfigureConsumer<AlbumConsumer>(context);
        });
        config.ReceiveEndpoint("user-deleted-artist-queue", c =>
        {
            c.ConfigureConsumer<UserDeletedConsumer>(context);
        });
    });
});

builder.Services.AddTransient<IArtistRepository, MockArtistRepository>();
//builder.Services.AddMassTransit(config =>
//{
//    config.UsingRabbitMq((context, config) =>
//    {
//        config.Host("rabbitmq:5672");
//    });
//});


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
