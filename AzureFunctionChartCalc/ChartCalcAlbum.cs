using AzureFunctionChartCalc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunctionChartCalc
{
    public class ChartCalcAlbum
    {
        public Album Album { get; set; }
        public double WeightedRating { get; set; }

        public ChartCalcAlbum(Album album, double weightedRating)
        {
            Album = album;
            WeightedRating = weightedRating;
        }
    }
}
