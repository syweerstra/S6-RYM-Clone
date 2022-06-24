using MusicService.Models;

namespace MusicService.Repositories
{
    public interface IAlbumRepository
    {
        Album GetById(int id);
        bool Add(Album musicRelease);
        Album AddRating(string userID, int albumID, int rating);
        bool DeleteRating(int albumID, string userID);
        bool DeleteAllRatings(List<int> albumIDs, string userID);
    }
}
