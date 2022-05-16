using MusicService.Models;

namespace MusicService.Repositories
{
    public interface IAlbumRepository
    {
        public Album GetById(int id);
        public bool Add(Album musicRelease);
    }
}
