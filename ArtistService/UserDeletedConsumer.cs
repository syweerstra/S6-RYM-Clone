using ArtistService.Repositories;
using MassTransit;
using RabbitMQLibrary.Models;

namespace ArtistService
{
    public class UserDeletedConsumer : IConsumer<UserDeletedMessage>
    {
        private readonly IArtistRepository repo;

        public UserDeletedConsumer(IArtistRepository repo)
        {
            this.repo = repo;
        }
        public Task Consume(ConsumeContext<UserDeletedMessage> context)
        {
            repo.DeleteUser(context.Message.AlbumsRatedIDs);
            return Task.CompletedTask;
        }
    }
}
