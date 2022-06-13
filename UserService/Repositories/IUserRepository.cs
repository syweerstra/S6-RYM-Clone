namespace UserService.Repositories
{
    public interface IUserRepository
    {
        User GetByName(string name);
        User GetByID(Guid id);
        int GetRating(int albumID, Guid userID);
        public User DeleteUser(Guid userId);
        public bool Rate(Rating rating);
    }
}
