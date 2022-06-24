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
                ReleaseDate = 2019,
                Artist = new Artist() { Id = 22, Name = "billy woods" },
                AverageRating = 0,
                Genres = "Abstract Hip Hop, East Coast Hip Hop",
                Languages = "English",
                Types = "Album, Collaboration",
                PositionInChart = 1,
                Descriptors = "abstract, depressive, male vocals, rhythmic, nihilistic, conscious, pessimistic, dark, cryptic, nocturnal, urban, serious, sampling, aggressive, anxious, angry, atmospheric, poetic, crime, cold, passionate, alienation, introspective, existential, deadpan, raw, drugs, disturbing, mysterious, death, hateful, suspenseful",
                AmountOfRatings = 0,
                AlbumCoverImageURL = "//e.snmc.io/i/600/w/d140053abffc487784367e5293fc1146/9570167/billy-woods-and-kenny-segal-hiding-places-Cover-Art.jpg"
            },
            new Album()
            {
                ID = 56,
                Name = "Aethiopes",
                ReleaseDate = 2022,
                Artist = new Artist() { Id = 22, Name = "billy woods" },
                AverageRating = 0,
                Genres = "Abstract Hip Hop, Experimental Hip Hop, East Coast Hip Hop, Conscious Hip Hop",
                Languages = "English",
                Types = "Album",
                PositionInChart = 0,
                Descriptors = "ominous, poetic, dark, cryptic, serious, sampling, mysterious, male vocals, atmospheric, conscious, raw, avant-garde, abstract, history, introspective, anxious, political, sombre, deadpan, urban, violence, nihilistic, crime, existential, folklore, suspenseful, death, alienation, ritualistic, tribal, spiritual",
                AmountOfRatings = 0,
                AlbumCoverImageURL = "//e.snmc.io/i/600/w/0a42135cdec55eb48f31c9fa4bdcee8e/9858657/billy-woods-aethiopes-Cover-Art.jpg"
            }
        };
        public bool Add(Album musicRelease)
        {
            throw new NotImplementedException();
            _albums.Add(musicRelease);
            return true;
        }

        public Album GetById(int id)
        {
           var album = _albums.Where(a => a.ID == id).FirstOrDefault();
            if (album == null)
                return _albums.FirstOrDefault();
            else
                return album;
            
        }

        public Album AddRating(string userID, int albumID, int rating)
        {
            var album = _albums.Where(x => x.ID == albumID).FirstOrDefault();
            album.Ratings.Add(new Rating() { UserID = userID, RatingOutOfTen = rating });
            album.AverageRating = RatingCalculations.CalculateAverage(album.Ratings.Select(r => r.RatingOutOfTen).ToList());
            album.AmountOfRatings++;
            return album;
        }

        public bool DeleteRating(int albumID, string userID)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAllRatings(List<int> albumIDs, string userID)
        {
            var albums = _albums.Where(a => albumIDs.Contains(a.ID)).ToList();
            foreach (var album in albums)
            {
                album.Ratings.Remove(album.Ratings.FirstOrDefault(r => r.UserID == userID));
                album.AmountOfRatings--;
                album.AverageRating = RatingCalculations.CalculateAverage(album.Ratings.Select(r => r.RatingOutOfTen).ToList());
            }

            return true;
        }
    }
}
