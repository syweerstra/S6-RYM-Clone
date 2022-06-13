using MassTransit;
using Microsoft.AspNetCore.Identity;
using RabbitMQLibrary.Models;

namespace AuthService
{
    public class DeleteUserConsumer : IConsumer<UserDeletedMessage>
    {
        private readonly UserManager<IdentityUser> userManager;

        public DeleteUserConsumer(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task Consume(ConsumeContext<UserDeletedMessage> context)
        {
            var user = await userManager.FindByIdAsync(context.Message.UserID.ToString());
            await userManager.DeleteAsync(user);
        }
    }
}
