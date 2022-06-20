using ArtistService.Models;

namespace ArtistService.Repositories
{
    public interface IArtistRepository
    {
        Artist GetByID(int id);
        void EditAlbum(int artistID, Album newVersionAlbum);
        void DeleteUser(List<int> albumIds);

    }
}
