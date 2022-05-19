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

        public bool Add(Album musicRelease)
        {
            try
            {
                context.MusicRelease.Add(musicRelease);
                return true;
            }
            catch (Exception e)
            {
                //TODO: Shouldn't catch base Exception but more specific -- should log
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public Album AddRating(int albumID, int rating)
        {
            throw new NotImplementedException();
        }

        public Album GetById(int id)
        {
           return context.MusicRelease.Find(id);
        }
    }
}
