namespace MusicService
{
    public static class RatingCalculations
    {
        public static double CalculateAverage(List<double> ratings)
        {
            if (ratings.Count == 0)
                return 0;
            else
                return ratings.Average();
        }
    }
}
