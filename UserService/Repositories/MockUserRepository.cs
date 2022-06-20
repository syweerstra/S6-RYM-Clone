namespace UserService.Repositories
{
    public class MockUserRepository : IUserRepository
    {
        static List<User> users = new()
        {
            new User()
            {
                Id = new Guid("2fdd793a-c35f-40d0-9ea1-36d4c15187cd"),
                Name = "Syweer",
                Age = 20,
                Gender = "Male",
                Ratings = new()
            }

        };
      
        public User GetByName(string name)
        {
            return users.Where(x => x.Name.ToUpper() == name.ToUpper()).FirstOrDefault();
        }

        public User DeleteUser(Guid userId)
        {
            User userDeleted = users.Where(x => x.Id == userId).FirstOrDefault();
            //User user = new User()
            //{
            //    Id = userDeleted.Id,
            //    Ratings = userDeleted.Ratings.ToList()
            //};
            userDeleted.Ratings = new(userDeleted.Ratings);
            users.Remove(userDeleted);

            return userDeleted;
        }
        public int GetRating(int albumID, Guid userID)
        {
            var user = users.Where(x => x.Id == userID).FirstOrDefault();
            Rating rating = null;
            if (user != null)
                 user.Ratings.Where(x => x.AlbumID == albumID).FirstOrDefault();

            if (rating != null)
                return rating.RatingOutOfTen;
            else
                return 0;
        }

        public bool Rate(Rating rating)
        {
            var r = users.Where(x => x.Id == rating.UserID).FirstOrDefault().Ratings.Where(x => x.AlbumID == rating.AlbumID).FirstOrDefault();
            if(r == null)
                users.Where(x => x.Id == rating.UserID).FirstOrDefault().Ratings.Add(rating);
            else
                r.RatingOutOfTen = rating.RatingOutOfTen;

            return true;
        }

        public User GetByID(Guid id)
        {
            return users.Where(u => u.Id == id).FirstOrDefault();
        }

        public User CreateUser(Guid userId, string username)
        {
            users.Add(new User() { Id = userId, Name = username, UserImageUrl = "https://e.snmc.io/i/600/w/d465f34f719feaa0793e1a17c7841f12/7689996" });
            return users.Last();
        }
    }
}
