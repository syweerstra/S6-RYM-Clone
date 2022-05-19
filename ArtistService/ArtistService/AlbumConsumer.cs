using ArtistService.Models;
using ArtistService.Repositories;
using MassTransit;
using RabbitMQLibrary.Models;

public class AlbumConsumer : IConsumer<AlbumChangedMessage>
{
    private readonly IArtistRepository repo;

    public AlbumConsumer(IArtistRepository repo)
    {
        this.repo = repo;
    }

    public Task Consume(ConsumeContext<AlbumChangedMessage> context)
    {
        var msg = context.Message;
        var a = new Album()
        {
            ID = msg.ID,
            AlbumCoverImageURL = msg.AlbumCoverImageURL,
            AmountOfRatings = msg.AmountOfRatings,
            AverageRating = msg.AverageRating,
            Name = msg.Name,
            ReleaseYear = msg.ReleaseDate
        };

        repo.EditAlbum(context.Message.ArtistID, a);
        return Task.CompletedTask;
    }
}