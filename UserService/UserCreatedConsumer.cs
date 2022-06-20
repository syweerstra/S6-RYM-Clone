using MassTransit;
using RabbitMQLibrary.Models;
using UserService.Repositories;

namespace UserService
{
    public class UserCreatedConsumer : IConsumer<UserCreatedMessage>
    {
        private readonly IUserRepository repo;

        public UserCreatedConsumer(IUserRepository repo)
        {
            this.repo = repo;
        }
        public Task Consume(ConsumeContext<UserCreatedMessage> context)
        {
            repo.CreateUser(context.Message.UserID, context.Message.Username);
            return Task.CompletedTask;
        }
    }
}
