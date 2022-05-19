﻿using UserService.DTOs;

namespace UserService.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlContext context;

        public UserRepository(SqlContext context)
        {
            this.context = context;
        }    
        public User GetByName(string name)
        {
            return context.Users.Find(name);
        }

        public int GetRating(int albumID, int userID)
        {
            var rating = context.Ratings.Where(x => x.AlbumID == albumID && x.UserID == userID).FirstOrDefault();
            if (rating != null)
                return rating.RatingOutOfTen;
            else
                return 0;
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
