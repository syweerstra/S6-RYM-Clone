using System;
using System.Collections.Generic;

namespace AzureFunctionChartCalc.Models
{
    public class Album
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Artist Artist { get; set; }
        public string Types { get; set; } 
        public string AlbumCoverImageURL { get; set; } 
        public int PositionInChart { get; set; }
        public int ReleaseDate { get; set; }
        public double AverageRating { get; set; }
        public int AmountOfRatings { get; set; }
        public ICollection<Rating> Ratings { get; set; } 
        public string Genres { get; set; } 
        public string Descriptors { get; set; } 
        public string Languages { get; set; }
        

    }
}