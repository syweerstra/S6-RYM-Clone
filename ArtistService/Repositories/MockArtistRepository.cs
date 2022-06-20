using ArtistService.Models;

namespace ArtistService.Repositories
{
    public class MockArtistRepository : IArtistRepository
    {
       static List<Artist> artists = new()
        {
            new Artist()
            {
                ID = 22,
                Name = "billy woods",
                BornIn = "Washington, DC, United States",
                CurrentlyIn = "New York, NY, United States",
                MemberOf = new()
                {
                    new Artist() { ID = 44, Name = "Super Chron Flight Brothers" },
                    new Artist() { ID = 22, Name = "Armand Hammer" },
                },
                Genres = new()
                {
                    new Genre() { ID = 1, Name = "East Coast Hip Hop"},
                    new Genre() { ID = 2, Name = "Abstract Hip Hop"},
                    new Genre() { ID = 3, Name = "Conscious Hip Hop"},
                    new Genre() { ID = 4, Name = "Hardcore Hip Hop"},
                    new Genre() { ID = 5, Name = "Experimental Hip Hop"}
                },
                Albums = new()
                {
                    new Album()
                    {
                        ID = 55,
                        Name = "Hiding Places",
                        AmountOfRatings = 0,
                        AmountOfReviews = 0,
                        AverageRating = 0.00,
                        ReleaseYear = 2019,
                        AlbumCoverImageURL = "//e.snmc.io/i/600/w/d140053abffc487784367e5293fc1146/9570167/billy-woods-and-kenny-segal-hiding-places-Cover-Art.jpg"
                    },
                    new Album()
                    {
                        ID = 56,
                        Name = "Aethiopes",
                        AmountOfRatings = 0,
                        AmountOfReviews = 0,
                        AverageRating = 0.00,
                        ReleaseYear = 2022,
                        AlbumCoverImageURL = "//e.snmc.io/i/600/w/0a42135cdec55eb48f31c9fa4bdcee8e/9858657/billy-woods-aethiopes-Cover-Art.jpg"
                        
                    }
                },
                ArtistImageURL = "//e.snmc.io/i/600/w/d140053abffc487784367e5293fc1146/9570167/billy-woods-and-kenny-segal-hiding-places-Cover-Art.jpg"
            }
        };

     
        public void EditAlbum(int artistID, Album newVersionAlbum)
        {
            var oldVersion = artists.FirstOrDefault(x => x.ID == artistID).Albums.Where(c => c.ID == newVersionAlbum.ID).FirstOrDefault();

            oldVersion.AmountOfRatings = newVersionAlbum.AmountOfRatings;
            oldVersion.AmountOfReviews = newVersionAlbum.AmountOfReviews;
            oldVersion.AverageRating = newVersionAlbum.AverageRating;
            oldVersion.Name = newVersionAlbum.Name;
            oldVersion.ReleaseYear = newVersionAlbum.ReleaseYear;
            
        }

        public void DeleteUser(List<int> albumIds)
        {
            //Horribly inefficient
            foreach (var artist in artists)
            {
                foreach (var album in artist.Albums)
                {
                    if (albumIds.Contains(album.ID))
                    {
                        album.AmountOfRatings--;
                        album.AverageRating = 0; //Not good
                    }
                    
                }
            }
        }

        public Artist GetByID(int id)
        {
            return artists.FirstOrDefault();
        }
    }
}
