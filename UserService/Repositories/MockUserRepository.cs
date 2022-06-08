namespace UserService.Repositories
{
    public class MockUserRepository : IUserRepository
    {
        static User user = new User()
        {
            Name = "Syweer",
            Age = 20,
            Gender = "Male",
            Ratings = new()
            {
                
            }
        };

      
        public User GetByName(string name)
        {
            return user;
        }

        public int GetRating(int albumID, Guid userID)
        {
            var rating = user.Ratings.Where(x => x.AlbumID == albumID).FirstOrDefault();
            if (rating != null)
                return rating.RatingOutOfTen;
            else
                return 0;
        }

        public bool Rate(Rating rating)
        {
            var r = user.Ratings.Where(x => x.AlbumID == rating.AlbumID).FirstOrDefault();
            if(r == null)
                user.Ratings.Add(rating);
            else
                r.RatingOutOfTen = rating.RatingOutOfTen;

            return true;
        }
    }
}
