using MusicService.Models;

namespace MusicService.Repositories
{
    public interface IAlbumRepository
    {
        Album GetById(int id);
        bool Add(Album musicRelease);
        Album AddRating(int albumID, int rating);

    }
}
