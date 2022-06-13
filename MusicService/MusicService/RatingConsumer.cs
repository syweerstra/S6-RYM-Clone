using MassTransit;
using MusicService.Repositories;
using RabbitMQLibrary.Models;

internal class RatingConsumer : IConsumer<AlbumRatedMessage>
{
    private readonly IAlbumRepository repo;
    private readonly IPublishEndpoint publishEndpoint;

    public RatingConsumer(IAlbumRepository repo, IPublishEndpoint publishEndpoint)
    {
        this.repo = repo;
        this.publishEndpoint = publishEndpoint;
    }


    public Task Consume(ConsumeContext<AlbumRatedMessage> context)
    {
        var album = repo.AddRating(context.Message.UserID, context.Message.AlbumID, context.Message.RatingOutOfTen);
        publishEndpoint.Publish(new AlbumChangedMessage()
        {
            ID = album.ID,
            Name = album.Name,
            ArtistID = album.Artist.Id,
            ReleaseDate = album.ReleaseDate,
            AlbumCoverImageURL = album.AlbumCoverImageURL,
            AmountOfRatings = album.AmountOfRatings,
            AverageRating = album.AverageRating
        });
        return Task.CompletedTask;
    }
}