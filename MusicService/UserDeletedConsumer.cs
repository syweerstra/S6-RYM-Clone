using MassTransit;
using MusicService.Repositories;
using RabbitMQLibrary.Models;

namespace MusicService
{
    public class UserDeletedConsumer : IConsumer<UserDeletedMessage>
    {
        private readonly IAlbumRepository repo;

        public UserDeletedConsumer(IAlbumRepository repo)
        {
            this.repo = repo;
        }
        public Task Consume(ConsumeContext<UserDeletedMessage> context)
        {
            repo.DeleteAllRatings(context.Message.AlbumsRatedIDs, context.Message.UserID);
            return Task.CompletedTask;
        }
    }
}
