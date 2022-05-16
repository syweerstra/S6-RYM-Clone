namespace UserService.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlContext context;

        public UserRepository(SqlContext context)
        {
            this.context = context;
        }    
        public User GetById(int id)
        {
            return context.Users.Find(id);

        }
        public bool Rate(Rating rating)
        {
            var existingRating = context.Ratings.Find(rating.AlbumID);
            if (existingRating == null)
                context.Ratings.Add(rating);
            else
                existingRating = rating;

            //TODO: return false also
            return true;
        }

        private void Save()
        {
            context.SaveChanges();
        }

       
    }
}
