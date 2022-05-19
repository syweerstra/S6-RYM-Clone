using MusicService.Models;

namespace MusicService.Repositories
{
    public class MockAlbumRepository : IAlbumRepository
    {
        static List<Album> _albums = new()
        {
            new Album()
            {
                ID = 55,
                Name = "Hiding Places",
                ReleaseDate = "29 March 2019",
                Artist = new Artist() { Id = 22, Name = "billy woods" },
                AverageRating = 0,
                Genres = "Abstract Hip Hop, East Coast Hip Hop",
                Languages = "English",
                Types = "Album, Collaboration",
                Descriptors = "abstract, depressive, male vocals, rhythmic, nihilistic, conscious, pessimistic, dark, cryptic, nocturnal, urban, serious, sampling, aggressive, anxious, angry, atmospheric, poetic, crime, cold, passionate, alienation, introspective, existential, deadpan, raw, drugs, disturbing, mysterious, death, hateful, suspenseful",
                AmountOfRatings = 0,
                AlbumCoverImageURL = "//e.snmc.io/i/600/w/d140053abffc487784367e5293fc1146/9570167/billy-woods-and-kenny-segal-hiding-places-Cover-Art.jpg"
            }
        };
        public bool Add(Album musicRelease)
        {
            throw new NotImplementedException();
        }

        public Album GetById(int id)
        {
            return _albums.FirstOrDefault();
        }

        public Album AddRating(int albumID, int rating)
        {
            var album = _albums.Where(x => x.ID == albumID).FirstOrDefault();
            album.Ratings.Add(rating);
            album.AverageRating = RatingCalculations.CalculateAverage(album.Ratings);
            album.AmountOfRatings++;
            return album;
        }
    }
}
