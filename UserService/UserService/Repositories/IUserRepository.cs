namespace UserService.Repositories
{
    public interface IUserRepository
    {
        User GetByName(string name);
        int GetRating(int albumID, int userID);
        public bool Rate(Rating rating);
    }
}
