namespace MusicService
{
    public static class RatingCalculations
    {
        public static double CalculateAverage(List<double> ratings)
        {
            return ratings.Average();
        }
    }
}
