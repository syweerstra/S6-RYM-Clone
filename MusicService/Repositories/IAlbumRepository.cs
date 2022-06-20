using MusicService.Models;

namespace MusicService.Repositories
{
    public interface IAlbumRepository
    {
        Album GetById(int id);
        bool Add(Album musicRelease);
        Album AddRating(Guid userID, int albumID, int rating);
        bool DeleteRating(int albumID, Guid userID);
        bool DeleteAllRatings(List<int> albumIDs, Guid userID);
    }
}
