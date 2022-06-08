namespace UserService
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? UserImageUrl { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string? Website { get; set; }
        public List<Rating> Ratings { get; set; }
    }
}