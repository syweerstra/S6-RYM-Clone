using Microsoft.EntityFrameworkCore;
using MusicService.Models;

namespace MusicService.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly SqlContext context;

        public AlbumRepository(SqlContext context)
        {
            this.context = context;
        }
        public List<Album> GetAllAlbums()
        {
            return context.Albums.ToList();
        }


        public bool Add(Album musicRelease)
        {
            try
            {
                context.Albums.Add(musicRelease);
                return true;
            }
            catch (Exception e)
            {
                //TODO: Shouldn't catch base Exception but more specific -- should log
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public Album AddRating(string userID, int albumID, int rating)
        {
            var album = context.Albums.Include("Artist").Include("Ratings").FirstOrDefault(a => a.ID == albumID);
            album.Ratings.Add(new Rating() { UserID = userID, RatingOutOfTen = rating, AlbumID = albumID });
            album.AverageRating = RatingCalculations.CalculateAverage(album.Ratings.Select(r => r.RatingOutOfTen).ToList());
            album.AmountOfRatings++;

            context.Albums.Update(album);
            context.SaveChanges();

            return album;
        }

        public bool DeleteAllRatings(List<int> albumIDs, string userID)
        {
            var albums = context.Albums.Include("Artist").Include("Ratings")
                .Where(a => albumIDs.Contains(a.ID)).ToList();

            foreach (var album in albums)
            {
                album.Ratings.Remove(album.Ratings.FirstOrDefault(r => r.UserID == userID));
                album.AmountOfRatings--;
                album.AverageRating = RatingCalculations.CalculateAverage(album.Ratings.Select(r => r.RatingOutOfTen).ToList());
            }

            context.Albums.UpdateRange(albums);
            context.SaveChanges();
            return true;
        }

        public bool DeleteRating(int albumID, string userID)
        {
            throw new NotImplementedException();
        }

        public Album GetById(int id)
        {
            return context.Albums.Include("Artist").Include("Ratings").FirstOrDefault(a => a.ID == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
